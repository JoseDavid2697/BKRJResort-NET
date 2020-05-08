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
    }
}
