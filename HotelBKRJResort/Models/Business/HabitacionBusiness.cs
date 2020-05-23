using HotelBKRJResort.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Business
{
    public class HabitacionBusiness
    {

        public IConfiguration Configuration { get; }

        public HabitacionBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Habitacion> obtenerEstadoHabitaciones()
        {
            HabitacionData habitacionData = new HabitacionData(this.Configuration);

            return habitacionData.obtenerEstadoHabitaciones();
        }

        public List<Habitacion> obtenerDisponibilidadHabitaciones(String fecha_llegada, String fecha_salida, int tipo_habitacion)
        {
            HabitacionData habitacionData = new HabitacionData(this.Configuration);

            return habitacionData.obtenerDisponibilidadHabitaciones(fecha_llegada,fecha_salida,tipo_habitacion);
        }
    }
}
