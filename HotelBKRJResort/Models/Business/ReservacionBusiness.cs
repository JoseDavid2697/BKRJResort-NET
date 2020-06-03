using HotelBKRJResort.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Business
{
    public class ReservacionBusiness
    {
        public IConfiguration Configuration { get; }

        public ReservacionBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Habitacion ValidarReservacion(String fecha_llegada, String fecha_salida, int tipo_habitacion)
        {
            ReservacionData reservacionData = new ReservacionData(this.Configuration);

            return reservacionData.ValidarReservacion(fecha_llegada,fecha_salida,tipo_habitacion);
        }

        public void insertarReservacion(Reservacion reservacion)
        {
            ReservacionData rd = new ReservacionData(this.Configuration);
            rd.InsertarReservacion(reservacion);
        }
        public Usuario obtenerUsuario(String identificacion)
        {
            ReservacionData reservacionData = new ReservacionData(this.Configuration);

            return reservacionData.obtenerUsuario(identificacion);
        }
    }
}
