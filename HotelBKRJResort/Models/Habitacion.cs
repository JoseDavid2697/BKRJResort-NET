using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models
{
    public class Habitacion
    {
        public int id_habitacion { set; get; }
        public int monto { set; get; }
        public string descripcion { set; get; }
        public string imagen { set; get; }
        public int resultado { set; get; }
        public string fecha_inicio { get; set; }
        public string fecha_final { get; set; }
    }
}
