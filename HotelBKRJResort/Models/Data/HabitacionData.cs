using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Data
{

    public class HabitacionData
    {
        public IConfiguration Configuration { get; }

        public HabitacionData(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public List<Habitacion> obtenerEstadoHabitaciones()
        {
            List<Habitacion> habitaciones = new List<Habitacion>();
            
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_consultarEstadoHabitacion]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Habitacion habitacion = new Habitacion();
                            habitacion.id_habitacion = Convert.ToInt32(dataReader["id"]);
                            habitacion.nombre = Convert.ToString(dataReader["nombre"]);
                            habitacion.estado = Convert.ToInt32(dataReader["estado"]);
                            habitacion.imagen = Convert.ToString(dataReader["imagen"]);
                            habitacion.fecha_final = Convert.ToString(dataReader["fechaReservaFinal"]);


                            habitaciones.Add(habitacion);
                        }

                    }
                }

                return habitaciones;
            }
        }

    }
}
