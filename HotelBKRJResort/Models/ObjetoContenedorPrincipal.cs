using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models
{
    public class ObjetoContenedorPrincipal
    {

        public List<Oferta> Ofertas { get; set; }

        public List<Tarifa> Tarifas { get; set; }

        public Habitacion Habitacion { get; set; }

        public MensajeReserva mensaje {get; set;}
    }
}
