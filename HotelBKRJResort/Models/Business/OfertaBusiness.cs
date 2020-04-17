using HotelBKRJResort.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Business
{
    public class OfertaBusiness
    {

        public IConfiguration Configuration { get; }

        public OfertaBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Oferta> ObtenerOfertas()
        {
            OfertaData ofertaData = new OfertaData(this.Configuration);

            return ofertaData.ObtenerOfertas();
        }
    }
}
