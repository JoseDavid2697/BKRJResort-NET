using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models
{
    public class Habitacion
    {
        public int id_habitacion { set; get; }
        public string nombre { set; get; }
        public int estado { set; get; }
        public int monto{ set; get; }
        public int resultado { set; get; }
        public string imagen { get; set; }
        public string descripcion { get; set; }
        public string fecha_inicio { get; set; }
        public string fecha_final { get; set; }

        public int precio { get; set; }
    }
}

