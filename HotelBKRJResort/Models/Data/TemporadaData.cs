using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Data
{
    public class TemporadaData
    {
        public IConfiguration Configuration { get; }

        public TemporadaData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Temporada> ObtenerTemporadas()
        {

            List<Temporada> temporadas = new List<Temporada>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtener_temporadas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Temporada temporada = new Temporada();
                            temporada.Id = Convert.ToInt32(dataReader["id"]);
                            temporada.Nombre = Convert.ToString(dataReader["nombre"]);
                            temporada.FechaInicio = Convert.ToString(dataReader["fechaInicio"]);
                            temporada.FechaFinal = Convert.ToString(dataReader["fechaFinal"]);
                            temporada.multiplicador = Convert.ToDouble(dataReader["multiplicadorPrecio"]);


                            temporadas.Add(temporada);
                        }

                    }
                }
                connection.Close();
            }

            return temporadas;
        }

        public List<Temporada> RegistrarTemporada(String nombre, String fechaInicio, String fechaFin, float multiplicador)
        {

            List<Temporada> temporadas = new List<Temporada>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (var connection = new SqlConnection(connectionString))
            {
                

                string sql = $"EXEC [dbo].[sp_insertar_temporada]'{nombre}','{fechaInicio}','{fechaFin}','{multiplicador}'";
                using (var command = new SqlCommand(sql, connection))
                {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                }

                connection.Open();
                sql = $"EXEC [dbo].[sp_obtener_temporadas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Temporada temporada = new Temporada();
                            temporada.Id = Convert.ToInt32(dataReader["id"]);
                            temporada.Nombre = Convert.ToString(dataReader["nombre"]);
                            temporada.FechaInicio = Convert.ToString(dataReader["fechaInicio"]);
                            temporada.FechaFinal = Convert.ToString(dataReader["fechaFinal"]);
                            temporada.multiplicador = Convert.ToDouble(dataReader["multiplicadorPrecio"]);


                            temporadas.Add(temporada);
                        }

                    }
                }
                connection.Close();
            }

            return temporadas;
        }

        public List<Temporada> ActualizarTemporada(int id, String nombre, String fechaInicio, String fechaFin, float multiplicador)
        {

            List<Temporada> temporadas = new List<Temporada>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (var connection = new SqlConnection(connectionString))
            {
                
                string sql = $"EXEC [dbo].[sp_actualizar_temporada]'{id}','{nombre}','{fechaInicio}','{fechaFin}','{multiplicador}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                connection.Open();
                sql = $"EXEC [dbo].[sp_obtener_temporadas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Temporada temporada = new Temporada();
                            temporada.Id = Convert.ToInt32(dataReader["id"]);
                            temporada.Nombre = Convert.ToString(dataReader["nombre"]);
                            temporada.FechaInicio = Convert.ToString(dataReader["fechaInicio"]);
                            temporada.FechaFinal = Convert.ToString(dataReader["fechaFinal"]);
                            temporada.multiplicador = Convert.ToDouble(dataReader["multiplicadorPrecio"]);


                            temporadas.Add(temporada);
                        }

                    }
                }
                connection.Close();
            }

            return temporadas;
        }


        public List<Temporada> EliminarTemporada(int id)
        {

            List<Temporada> temporadas = new List<Temporada>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (var connection = new SqlConnection(connectionString))
            {

                string sql = $"EXEC [dbo].[sp_eliminar_temporada]'{id}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                connection.Open();
                sql = $"EXEC [dbo].[sp_obtener_temporadas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Temporada temporada = new Temporada();
                            temporada.Id = Convert.ToInt32(dataReader["id"]);
                            temporada.Nombre = Convert.ToString(dataReader["nombre"]);
                            temporada.FechaInicio = Convert.ToString(dataReader["fechaInicio"]);
                            temporada.FechaFinal = Convert.ToString(dataReader["fechaFinal"]);
                            temporada.multiplicador = Convert.ToDouble(dataReader["multiplicadorPrecio"]);


                            temporadas.Add(temporada);
                        }

                    }
                }
                connection.Close();
            }

            return temporadas;
        }
        
    }
}
