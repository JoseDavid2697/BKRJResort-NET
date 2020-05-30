using HotelBKRJResort.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Business
{
    public class TarifaBusiness
    {

        public IConfiguration Configuration { get; }

        public TarifaBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Tarifa> ObtenerTarifas()
        {
            TarifaData tarifaData = new TarifaData(this.Configuration);

            return tarifaData.ObtenerTarifas();
        }

        public Tarifa ObtenerTarifaStandard()
        {
            TarifaData tarifaData = new TarifaData(this.Configuration);

            return tarifaData.ObtenerTarifaStandard();
        }

        public Tarifa ObtenerTarifaJunior()
        {
            TarifaData tarifaData = new TarifaData(this.Configuration);

            return tarifaData.ObtenerTarifaJunior();
        }

        public void ActualizarTarifa(int id, double precio, String descripcion)
        {

            TarifaData tarifaData = new TarifaData(this.Configuration);

            tarifaData.ActualizarTarifa(id, precio, descripcion);

        }
    }
}
