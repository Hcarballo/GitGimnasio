using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Models
{
    public class Gym
    {
        public int ID { get; set; }
        public string Razon_Social { get; set; }
        public string Logo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public Double Latitud { get; set; }
        public Double Longitud { get; set; }

        public List<Horario> Horario { get; set; }
        public List<Blog> Blog { get; set; }
        public ICollection<Socio> Socio { get; set; }
        public ICollection<Profesor> Profesor { get; set; }
        public ICollection<Clase> Clase { get; set; }
        public ICollection<Cuota> Cuota { get; set; }
    }
}
