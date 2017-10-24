using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Models
{
    public class Socio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Foto { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public string Telefono { get; set; }
        public string Telefono_Fam { get; set; }
        public string DNI { get; set; }
        public string Direccion { get; set; }
        public bool Certificado { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public DateTime Fecha_Ing { get; set; }
        public bool Activo { get; set; }

        public ICollection<Pago> Pago { get; set; }
    }
}
