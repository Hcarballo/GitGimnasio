using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Data;
using Gimnasio.Models;
using Gimnasio.Models.AccountViewModels;

namespace Gimnasio.Controllers
{
    public class SociosController : Controller
    {
        private readonly GimnasioDbContext _context;

        public SociosController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: Socios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Socios.ToListAsync());
        }

        // GET: Socios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .SingleOrDefaultAsync(m => m.ID == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // GET: Socios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Socios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Apellido,Foto,Fecha_Nac,Telefono,Telefono_Fam,DNI,Direccion,Certificado,Localidad,Provincia,Fecha_Ing,Activo")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socio);
        }

        public IActionResult Ingresos()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Ingresos([Bind("dni")]string dni)
        //{
        //    var socio = await _context.Socios.Where(x => x.DNI == dni).FirstOrDefaultAsync();
        //    if (socio != null)
        //    {
        //        SocioViewModel socioVM = new SocioViewModel();
        //        Pago pago = await _context.Pagos.Where(x => x.Socio.ID == socio.ID).LastOrDefaultAsync();

        //        socioVM.Activo = socio.Activo;
        //        socioVM.Apellido = socio.Apellido;
        //        socioVM.Nombre = socio.Nombre;
        //        socioVM.Dni = socio.DNI;
        //        socioVM.Fecha_Ing = socio.Fecha_Ing;
        //        if (pago != null)
        //        {
        //            socioVM.Ultimo_Pago = pago.Fecha_Pago;
        //            if (pago.Fecha_Pago.Month != DateTime.Today.Month && pago.Fecha_Pago.Year != DateTime.Today.Year)
        //            {
        //                socioVM.Cuota = "El socio debe" + Convert.ToInt16(DateTime.Today - pago.Fecha_Pago) + "dias";
        //            }
        //            else
        //            {
        //                socioVM.Cuota = "Cuota al dia";
        //            }
        //        }
        //        else
        //        {
        //            socioVM.Cuota = "No se registran Pagos";
        //        }

        //        return View("_Ingresos", socioVM);
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}

       [HttpPost]
        public ActionResult Ingresos(string dni)
        {
            var socio = _context.Socios.Where(x => x.DNI == dni).FirstOrDefault();
            if (socio != null)
            {
                SocioViewModel socioVM = new SocioViewModel();
                Pago pago = _context.Pagos.Where(x => x.Socio.ID == socio.ID).LastOrDefault();

                socioVM.Activo = socio.Activo;
                socioVM.Apellido = socio.Apellido;
                socioVM.Nombre = socio.Nombre;
                socioVM.Dni = socio.DNI;
                socioVM.Fecha_Ing = socio.Fecha_Ing;
                if (pago != null)
                {
                    socioVM.Ultimo_Pago = pago.Fecha_Pago;
                    if (pago.Fecha_Pago.Month != DateTime.Today.Month && pago.Fecha_Pago.Year != DateTime.Today.Year)
                    {
                        socioVM.Cuota = "El socio debe" + Convert.ToInt16(DateTime.Today - pago.Fecha_Pago) + "dias";
                    }
                    else
                    {
                        socioVM.Cuota = "Cuota al dia";
                    }
                }
                else
                {
                    socioVM.Cuota = "No se registran Pagos";
                }

                return View("_Ingresos", socioVM);
            }
            else
            {
                return View();
            }

        }


        // GET: Socios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios.SingleOrDefaultAsync(m => m.ID == id);
            if (socio == null)
            {
                return NotFound();
            }
            return View(socio);
        }

        // POST: Socios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Apellido,Foto,Fecha_Nac,Telefono,Telefono_Fam,DNI,Direccion,Certificado,Localidad,Provincia,Fecha_Ing,Activo")] Socio socio)
        {
            if (id != socio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocioExists(socio.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(socio);
        }

        // GET: Socios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .SingleOrDefaultAsync(m => m.ID == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socio = await _context.Socios.SingleOrDefaultAsync(m => m.ID == id);
            _context.Socios.Remove(socio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocioExists(int id)
        {
            return _context.Socios.Any(e => e.ID == id);
        }
    }
}
