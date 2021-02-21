using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloomManager.Web
{
    public class PartyController : Controller
    {
        public ActionResult PartyTools()
        {
            return View();
        }
    }
}