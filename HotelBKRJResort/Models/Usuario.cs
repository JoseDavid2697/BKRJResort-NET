using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string contra { get; set; }
        public int tipo { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string tarjeta { get; set; }
    }
}
