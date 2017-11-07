using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;

namespace Gimnasio.Controllers
{
    public class CuotasController : Controller
    {
        private readonly GimnasioDbContext _context;

        public CuotasController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: Cuotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuotas.ToListAsync());
        }       

        // GET: Cuotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuotas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Fecha,Cuota_Club,Cuota_Gym,Activa")] Cuota cuota)
        {
            if (ModelState.IsValid)
            {
                var lastCuota = _context.Cuotas.Last();
                lastCuota.Activa = false;
                _context.Entry(lastCuota).State = EntityState.Modified;
                _context.Add(cuota);                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuota);
        }      
    }
}
