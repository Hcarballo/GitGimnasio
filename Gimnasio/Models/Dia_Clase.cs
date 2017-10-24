using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Models
{
    public enum Dia
    {
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado
    }

    public class Dia_Clase
    {
        public int ID { get; set; }
        public DateTime Hora_Ini { get; set; }
        public DateTime Hora_Fin { get; set; }
        public string Profesor { get; set; }

        public Dia Dia { get; set; }
    }
}
