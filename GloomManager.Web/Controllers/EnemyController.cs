using AutoMapper;
using GloomManager.Data.Services;
using GloomManager.Web.Models;
using GloomManager.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GloomManager.Web.Controllers
{
    public class EnemyController : Controller
    {
        private readonly IEnemyManager _enemyManager;
        private readonly IHtmlHelper _htmlHelper;
        private readonly IMapper _mapper;

        public EnemyController(IEnemyManager enemyManager,
                               IHtmlHelper htmlHelper,
                               IMapper mapper)
        {
            this._enemyManager = enemyManager;
            this._htmlHelper = htmlHelper;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult UniqueIndex(string searchName)
        {
            var model = _enemyManager.GetUniqueEnemiesByName(searchName ?? "");
            var viewModel = _mapper.Map<List<EnemyFormViewModel>>(model);
            TempData["SearchName"] = searchName;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FullIndex(string searchName = "")
        {
            var model = _enemyManager.GetEnemiesByName(searchName ?? "");
            var viewModel = _mapper.Map<List<EnemyFormViewModel>>(model);
            TempData["SearchName"] = searchName;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(string name, int level = 0, EnemyEliteness eliteness = 0)
        {
            var model = _enemyManager.GetEnemyByNameElitenessLevel(name, eliteness, level);
            if (model is null)
                return View("NotFound");
            var viewModel = _mapper.Map<EnemyFormViewModel>(model);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Update(int id = -1)
        {
           EnemyFormViewModel model;
            if (id < 0) // creating new
            {
                model = new EnemyFormViewModel { Id = id };
            }
            else // updating existing
            {
                var domain = _enemyManager.GetOne(id);
                model = _mapper.Map<EnemyFormViewModel>(domain);
            }
            model.EnemyTypeOptions = _htmlHelper.GetEnumSelectList<EnemyType>();
            model.EnemyElitenessesOptions = _htmlHelper.GetEnumSelectList<EnemyEliteness>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EnemyFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.EnemyTypeOptions = _htmlHelper.GetEnumSelectList<EnemyType>();
                model.EnemyElitenessesOptions = _htmlHelper.GetEnumSelectList<EnemyEliteness>();
                return View(model);
            }

            if (model.IsUpdate)
            {
                var domain = _enemyManager.GetOne(model.Enemy.Id);
                _mapper.Map(model, domain);
                _enemyManager.Save(domain);
            }
            else
            {
                if (!NameLevelElitenessIsUnique(model.Enemy))
                {
                    TempData["AlertMessage"] = "Name/Level/Eliteness combination is not unique.";
                    model.EnemyTypeOptions = _htmlHelper.GetEnumSelectList<EnemyType>();
                    model.EnemyElitenessesOptions = _htmlHelper.GetEnumSelectList<EnemyEliteness>();
                    return View(model);
                }
                _enemyManager.Add(model.Enemy);
            }   

            TempData["AlertMessage"] = model.IsUpdate ? "Enemy updated!" : "Enemy added!";
            return RedirectToAction("FullIndex");
        }

        private bool NameLevelElitenessIsUnique(Enemy proposedEnemy)
        {
            var allEnemies = _enemyManager.GetAll();
            var existingEnemy = allEnemies.FirstOrDefault(e => 
                e.Name == proposedEnemy.Name &&
                e.Level == proposedEnemy.Level &&
                e.Eliteness == proposedEnemy.Eliteness);
            return existingEnemy is null;
        }
    }
}
