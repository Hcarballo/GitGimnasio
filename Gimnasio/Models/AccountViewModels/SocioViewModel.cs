using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Models.AccountViewModels
{
    public class SocioViewModel
    {
        public string ID { get; set; }
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Display(Name = "DNI")]
        public string Dni { get; set; }
        [Display(Name = "Fecha Ingreso")]
        public DateTime Fecha_Ing { get; set; }
        [Display(Name = "Activo")]
        public bool Activo { get; set; }
        [Display(Name = "Fecha Ultimo Pago")]
        public DateTime Ultimo_Pago { get; set; }
        [Display(Name = "Estado de Cuota")]
        public string Cuota { get; set; }
    }
}
