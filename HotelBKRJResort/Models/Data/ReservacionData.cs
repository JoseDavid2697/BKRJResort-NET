using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Data
{

    public class ReservacionData
    {
        public IConfiguration Configuration { get; }

        public ReservacionData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Habitacion ValidarReservacion(String fecha_llegada, String fecha_salida, int tipo_habitacion)
        {

            Habitacion habitacion = new Habitacion();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtenerHabitacionDisponible]'{fecha_llegada}','{fecha_salida}',{tipo_habitacion}";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {

                        dataReader.Read();
                        if (Convert.ToInt32(dataReader["resultado"]) != 0)
                        {
                            habitacion.id_habitacion = Convert.ToInt32(dataReader["id"]);
                            habitacion.monto = Convert.ToInt32(dataReader["monto"]);
                            habitacion.descripcion = dataReader["descripcion"].ToString();
                            habitacion.imagen = dataReader["imagen"].ToString();
                            habitacion.resultado = Convert.ToInt32(dataReader["resultado"]);
                            habitacion.fecha_inicio = dataReader["inicio"].ToString();
                            habitacion.fecha_final = dataReader["final"].ToString();
                        }
                        else
                        {
                            habitacion.resultado = Convert.ToInt32(dataReader["resultado"]);
                        }

                    }
                    connection.Close();
                }

                return habitacion;
            }
        }

        public void InsertarReservacion(Reservacion reservacion)
        {

            

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_insertar_reserva]{reservacion.id_habitacion},{reservacion.monto},'{reservacion.fecha_inicio.ToString("yyyy-MM-dd")}','{reservacion.fecha_final.ToString("yyyy-MM-dd")}','{reservacion.nombre}','{reservacion.apellidos}','{reservacion.email}','{reservacion.tarjeta}','{reservacion.codigo}','{reservacion.identificacion}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
