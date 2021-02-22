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
        public IActionResult Index(string searchName)
        {
            var model = enemyManager.GetUniqueEnemiesByName(searchName ?? "");
            var viewModel = mapper.Map<List<EnemyViewModel>>(model);
            TempData["SearchName"] = searchName;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(string name, int level = 0, EnemyElitenessViewModel eliteness = 0)
        {
            var elitenessModel = mapper.Map<EnemyEliteness>(eliteness);
            var model = enemyManager.GetEnemyByNameElitenessLevel(name, elitenessModel, level);
            var viewModel = mapper.Map<EnemyViewModel>(model);
            if (viewModel is null)
                return View("NotFound");
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
