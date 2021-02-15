using AutoMapper;
using GloomManager.Data.Services;
using GloomManager.Web.Models;
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
        public IActionResult Index()
        {
            var model = enemyManager.GetAll();
            var viewModel = mapper.Map<List<EnemyViewModel>>(model);
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var model = enemyManager.GetOne(id);
            var viewModel = mapper.Map<EnemyViewModel>(model);
            return View(viewModel);
        }
    }
}
