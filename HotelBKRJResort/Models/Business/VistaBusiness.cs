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

        //SOBRE NOSOTROS
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

        //FACILIDADES
        public Vista obtenerFacilidades()
        {
            VistaData vistaData = new VistaData(this.Configuration);

            return vistaData.obtenerFacilidades();
        }

        public Vista actualizarFacilidades(Vista vista)
        {
            VistaData vistaData = new VistaData(this.Configuration);

            return vistaData.actualizarFacilidades(vista);
        }
      
      //COMO LLEGAR
        public Vista obtenerComoLlegar()
        {
            VistaData vistaData = new VistaData(this.Configuration);

            return vistaData.obtenerComoLlegar();
        }

        public Vista actualizarComoLlegar(Vista vista)
        {
            VistaData vistaData = new VistaData(this.Configuration);

            return vistaData.actualizarComoLlegar(vista);
        }

        //HOME
        public Vista obtenerHome()
        {
            VistaData vistaData = new VistaData(this.Configuration);

            return vistaData.obtenerHome();
        }

        public Vista actualizarHome(Vista vista)
        {
            VistaData vistaData = new VistaData(this.Configuration);

            return vistaData.actualizarHome(vista);
        }

    }
}

