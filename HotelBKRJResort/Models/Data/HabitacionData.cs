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

        public List<Habitacion> obtenerDisponibilidadHabitaciones(String fecha_llegada, String fecha_salida, int tipo_habitacion)
        {
            List<Habitacion> habitaciones = new List<Habitacion>();
            
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_consultarDisponibilidadHabitaciones]'{fecha_llegada}','{fecha_salida}',{tipo_habitacion}";
                using (var command = new SqlCommand(sql, connection))
                {
                    
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Habitacion habitacion = new Habitacion();
                            if (Convert.ToInt32(dataReader["resultado"]) == 1)
                            {
                               
                                habitacion.id_habitacion = Convert.ToInt32(dataReader["id"]);
                                habitacion.nombre = Convert.ToString(dataReader["tipo"]);
                                habitacion.precio = Convert.ToInt32(dataReader["costo"]);
                                habitacion.resultado = Convert.ToInt32(dataReader["resultado"]);
                            }
                            else
                            {
                                habitacion.resultado = Convert.ToInt32(dataReader["resultado"]);

                            }



                            habitaciones.Add(habitacion);
                        }

                    }
                }

                return habitaciones;
            }
        }
    }
}
