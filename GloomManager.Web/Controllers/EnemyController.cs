using GloomManager.Data.Services;
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

        public EnemyController(IEnemyManager enemyManager)
        {
            this.enemyManager = enemyManager;
        }
        public IActionResult Index()
        {
            var model = enemyManager.GetAll();
            return View(model);
        }
    }
}
