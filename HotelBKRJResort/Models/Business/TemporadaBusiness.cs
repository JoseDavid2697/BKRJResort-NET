using HotelBKRJResort.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Business
{
    public class TemporadaBusiness
    {

        public IConfiguration Configuration { get; }

        public TemporadaBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Temporada> ObtenerTemporadas()
        {
            TemporadaData temporadaData = new TemporadaData(this.Configuration);

            return temporadaData.ObtenerTemporadas();
        }

        public List<Temporada> RegistrarTemporada(String nombre, String fechaInicio, String fechaFin, float multiplicador)
        {
            TemporadaData temporadaData = new TemporadaData(this.Configuration);

            return temporadaData.RegistrarTemporada(nombre, fechaInicio, fechaFin, multiplicador);
        }

        public List<Temporada> ActualizarTemporada(int id, String nombre, String fechaInicio, String fechaFin, float multiplicador)
        {
            TemporadaData temporadaData = new TemporadaData(this.Configuration);

            return temporadaData.ActualizarTemporada(id, nombre, fechaInicio, fechaFin, multiplicador);
        }

        public List<Temporada> EliminarTemporada(int id)
        {
            TemporadaData temporadaData = new TemporadaData(this.Configuration);

            return temporadaData.EliminarTemporada(id);
        }

    }
}
