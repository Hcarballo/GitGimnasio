using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Gimnasio.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gimnasio.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe contener minimo de {2} y un maximo de {1} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "El password y la confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Perfil")]
        [UIHint("List")]
        public List<SelectListItem> Roles { get; set; }
        public  IEnumerable<string> Role { get; set; }        

        public RegisterViewModel()
        {
            Roles = new List<SelectListItem>();
        }
        
        public void getRoles(GimnasioDbContext context, string user)
        {
            var userAct = context.Users.Where(x => x.Email == user).FirstOrDefault();
            var rolUser = context.UserRoles.Where(x => x.UserId == userAct.Id).FirstOrDefault();
            var rolName = context.Roles.Where(x => x.Id == rolUser.RoleId).FirstOrDefault();
            var roles = from r in context.identityRole select r;
            var listRole = roles.ToList();

            foreach(var Data in listRole)
            {
                if (rolName.Name == "Desarrollador")
                {
                    Roles.Add(new SelectListItem()
                    {
                        Value = Data.Id,
                        Text = Data.Name,
                    });
                }
                if (rolName.Name == "Administrador" && Data.Name != "Desarrollador")
                {
                    Roles.Add(new SelectListItem()
                    {
                        Value = Data.Id,
                        Text = Data.Name,
                    });
                }            
               
            }
        }
    }
}
