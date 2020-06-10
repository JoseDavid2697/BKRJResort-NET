using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models
{
    public class Reservacion
    {
        public int id { get; set; }
        public String tipoHabitacion { get; set; }
        public int id_habitacion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public String email { get; set; }
        public String tarjeta { get; set; }
        public int monto { get; set; }

        public String codigo { get; set; }

        public String identificacion { get; set; }
    }
}
