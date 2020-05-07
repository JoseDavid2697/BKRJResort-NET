using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models
{
    public class Tarifa
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public float Precio{ get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

    }
}
