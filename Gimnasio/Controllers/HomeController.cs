using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gimnasio.Models;
using Microsoft.AspNetCore.Authorization;

namespace Gimnasio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Desarrollador")]
        public IActionResult HomeDesarrollador()
        {
            return View();
        }

        [Authorize(Roles ="Desarrollador, Administrador")]
        public IActionResult HomeAdministrador()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
