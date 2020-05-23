using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models
{
    public class Temporada
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public double multiplicador { get; set; }
        public int TipoTemporada{ get; set; }
    }
}
