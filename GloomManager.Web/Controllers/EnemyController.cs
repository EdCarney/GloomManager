using AutoMapper;
using GloomManager.Data.Services;
using GloomManager.Web.Models;
using GloomManager.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloomManager.Web.Controllers
{
    public class EnemyController : Controller
    {
        private readonly IEnemyManager enemyManager;
        private readonly IMapper mapper;

        public EnemyController(IEnemyManager enemyManager,
                               IMapper mapper)
        {
            this.enemyManager = enemyManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult UniqueIndex(string searchName)
        {
            var model = enemyManager.GetUniqueEnemiesByName(searchName ?? "");
            var viewModel = new List<EnemyFormViewModel>();
            foreach (var m in model)
            {
                viewModel.Add(new EnemyFormViewModel
                {
                    Id = m.Id,
                    Enemy = mapper.Map<EnemyViewModel>(m)
                });
            }
            TempData["SearchName"] = searchName;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FullIndex(string searchName)
        {
            var model = enemyManager.GetEnemiesByName(searchName ?? "");
            var viewModel = mapper.Map<List<EnemyViewModel>>(model);
            TempData["SearchName"] = searchName;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(string name, int level = 0, EnemyElitenessViewModel eliteness = 0)
        {
            var elitenessModel = mapper.Map<EnemyEliteness>(eliteness);
            var model = enemyManager.GetEnemyByNameElitenessLevel(name, elitenessModel, level);
            if (model is null)
                return View("NotFound");
            var viewModel = mapper.Map<EnemyFormViewModel>(model);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EnemyFormViewModel { Id = -1 };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EnemyFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var domain = mapper.Map<Enemy>(model.Enemy);
            enemyManager.Add(domain);
            return View("FullIndex", "");
        }

        [HttpGet]
        public IActionResult Update(int id = -1)
        {
            var model = new EnemyFormViewModel { Id = id };
            model.Enemy = mapper.Map<EnemyViewModel>(enemyManager.GetOne(id));
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EnemyFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            return UniqueIndex("");
        }
    }
}
