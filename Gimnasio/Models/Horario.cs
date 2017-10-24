using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Models
{
    public class Horario
    {
        public int ID { get; set; }
        public Dia Dia { get; set; }
        public DateTime Hora_Ini { get; set; }
        public DateTime Hora_Fin { get; set; }
    }
}
