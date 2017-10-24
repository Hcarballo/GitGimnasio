using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Models
{
    public class Clase
    {
        public int ID { get; set; }
        public string Actividad { get; set; }
        public string descripcion { get; set; }
        public bool Activa { get; set; }

        public ICollection<Dia_Clase> Dia_Clase { get; set; }
    }
}
