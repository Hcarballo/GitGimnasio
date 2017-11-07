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
    public class ApplicationUsersController : Controller
    {
        private readonly GimnasioDbContext _context;

        public ApplicationUsersController(GimnasioDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            var contex = await _context.ApplicationUser.ToListAsync();
            var user = await _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefaultAsync();
            var userRol = await _context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
            var perfil = await _context.Roles.Where(x => x.Id == userRol.RoleId).FirstOrDefaultAsync();

            ViewBag.viewBag = perfil.Name;

            List<UserViewModel> model = new List<UserViewModel>();

            foreach (var i in contex)
            {
                UserViewModel userView = new UserViewModel();
                userView.ID = i.Id;
                userView.Nombre = i.UserName;
                userView.Email = i.Email;
                var rol = _context.UserRoles.Where(x => x.UserId == i.Id).FirstOrDefault();
                var role = _context.Roles.Where(x => x.Id == rol.RoleId).FirstOrDefault();
                userView.Perfil = role.Name;
                userView.Activo = i.Activo;

                model.Add(userView);
            }
            
            return View(model.ToList());
        }

       
        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {
            return RedirectToAction("Register","Account");
        }
       
        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {                
                return NotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,Activo")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
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
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
