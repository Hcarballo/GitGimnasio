using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Models
{
    public class Cuota
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cuota_Club { get; set; }
        public decimal Cuota_Gym { get; set; }
        public bool Activa { get; set; }
    }
}
