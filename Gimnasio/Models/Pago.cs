using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Models
{
    public class Pago
    {
        public int ID { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public double Cuota_Club { get; set; }
        public double Cuota_Gym { get; set; }

        public Socio Socio { get; set; }
    }
}
