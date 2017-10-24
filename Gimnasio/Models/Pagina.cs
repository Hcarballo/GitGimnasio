using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Models
{
    public class Pagina
    {
        public int ID { get; set; }
        public string Etiqueta { get; set; }
        public string URL { get; set; }
        public bool Activa { get; set; }
    }
}
