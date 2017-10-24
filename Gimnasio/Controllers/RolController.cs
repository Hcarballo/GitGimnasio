using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Gimnasio.Data;

namespace Gimnasio.Controllers
{
    public class RolController : Controller
    {
        GimnasioDbContext context;

            
        public IActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }
    }
}