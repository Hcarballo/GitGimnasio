using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Gimnasio.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace Gimnasio.Models.AccountViewModels
{
    public class UserViewModel
    {
        public string ID { get; set; }
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Activo")]
        public bool Activo { get; set; }
        [Display(Name = "Perfil")]
        public string Perfil { get; set; }      
    }      
}
