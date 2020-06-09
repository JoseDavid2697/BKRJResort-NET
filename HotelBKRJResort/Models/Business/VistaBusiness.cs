using HotelBKRJResort.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Business
{
    public class VistaBusiness
    {
        public IConfiguration Configuration { get; }

        public VistaBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Vista obtenerSobreNosotros()
        {
            VistaData vistaData = new VistaData(this.Configuration);

            return vistaData.obtenerSobreNosotros();
        }

        public Vista actualizarSobreNosotros(Vista vista)
        {
            VistaData vistaData = new VistaData(this.Configuration);

            return vistaData.actualizarSobreNosotros(vista);
        }
        
    }
}

