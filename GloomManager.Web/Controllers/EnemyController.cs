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
        private readonly IEnemyManager enemyManager;
        private readonly IHtmlHelper htmlHelper;
        private readonly IMapper mapper;

        public EnemyController(IEnemyManager enemyManager,
                               IHtmlHelper htmlHelper,
                               IMapper mapper)
        {
            this.enemyManager = enemyManager;
            this.htmlHelper = htmlHelper;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult UniqueIndex(string searchName)
        {
            var model = enemyManager.GetUniqueEnemiesByName(searchName ?? "");
            var viewModel = mapper.Map<List<EnemyFormViewModel>>(model);
            TempData["SearchName"] = searchName;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FullIndex(string searchName = "")
        {
            var model = enemyManager.GetEnemiesByName(searchName ?? "");
            var viewModel = mapper.Map<List<EnemyFormViewModel>>(model);
            TempData["SearchName"] = searchName;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(string name, int level = 0, EnemyEliteness eliteness = 0)
        {
            var model = enemyManager.GetEnemyByNameElitenessLevel(name, eliteness, level);
            if (model is null)
                return View("NotFound");
            var viewModel = mapper.Map<EnemyFormViewModel>(model);

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
                var domain = enemyManager.GetOne(id);
                model = mapper.Map<EnemyFormViewModel>(domain);
            }
            model.EnemyTypeOptions = htmlHelper.GetEnumSelectList<EnemyType>();
            model.EnemyElitenessesOptions = htmlHelper.GetEnumSelectList<EnemyEliteness>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EnemyFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Enemy domain = model.Enemy;
            if (!NameLevelElitenessIsUnique(domain))
            {
                TempData["AlertMessage"] = "Name/Level/Eliteness combination is not unique.";
                return View(model);
            }
            enemyManager.Add(domain);
            TempData["AlertMessage"] = "Enemy added!";
            return RedirectToAction("FullIndex");
        }

        private bool NameLevelElitenessIsUnique(Enemy proposedEnemy)
        {
            var allEnemies = enemyManager.GetAll();
            var existingEnemy = allEnemies.FirstOrDefault(e => 
                e.Name == proposedEnemy.Name &&
                e.Level == proposedEnemy.Level &&
                e.Eliteness == proposedEnemy.Eliteness);
            return existingEnemy is null;
        }

        // [HttpGet]
        // public IActionResult Update(int id = -1)
        // {
        //     EnemyFormViewModel model;
        //     if (id < 0) // creating new
        //     {
        //         model = new EnemyFormViewModel { Id = id };
        //     }
        //     else // updating existing
        //     {
        //         var domain = enemyManager.GetOne(id);
        //         model = mapper.Map<EnemyFormViewModel>(domain);
        //     }

        //     return View(model);
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public IActionResult Update(EnemyFormViewModel model)
        // {
        //     if (!ModelState.IsValid)
        //         return View(model);
        //     return UniqueIndex("");
        // }
    }
}
