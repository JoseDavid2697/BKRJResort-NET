﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Data
{
    public class TarifaData
    {

        public IConfiguration Configuration { get; }

        public TarifaData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Tarifa> ObtenerTarifas()
        {

            List<Tarifa> tarifas = new List<Tarifa>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtener_tarifas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Tarifa tarifa = new Tarifa();
                            tarifa.Id = Convert.ToInt32(dataReader["id"]);
                            tarifa.Nombre = Convert.ToString(dataReader["nombre"]);
                            tarifa.Precio = Convert.ToInt32(dataReader["precio"]);
                            tarifa.Descripcion = Convert.ToString(dataReader["descripcion"]);
                            tarifa.Imagen = Convert.ToString(dataReader["imagen"]);

                            tarifas.Add(tarifa);
                        }

                    }
                }
                connection.Close();
            }

            return tarifas;
        }

        public Tarifa ObtenerTarifaStandard()
        {

            Tarifa t = new Tarifa();


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtener_tarifa_standard]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {


                            t.Precio = Convert.ToInt32(dataReader["precio"]);
                            t.Descripcion = Convert.ToString(dataReader["descripcion"]);
                            t.Imagen = Convert.ToString(dataReader["imagen"]);

                        }

                    }
                }
                connection.Close();
            }


            return t;
        }

        public Tarifa ObtenerTarifaJunior()
        {

            Tarifa t = new Tarifa();


            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtener_tarifa_junior]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {


                            t.Precio = Convert.ToInt32(dataReader["precio"]);
                            t.Descripcion = Convert.ToString(dataReader["descripcion"]);
                            t.Imagen = Convert.ToString(dataReader["imagen"]);

                        }

                    }
                }
                connection.Close();
            }


            return t;
        }

        public void ActualizarTarifa(int id, double precio, String descripcion)
        {

            List<Temporada> temporadas = new List<Temporada>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (var connection = new SqlConnection(connectionString))
            {

                string sql = $"EXEC [dbo].[sp_actualizar_tarifa]'{id}','{precio}','{descripcion}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }

        public List<Habitacion> ObtenerHabitaciones(int idTarifa)
        {
            List<Habitacion> habitacionesStandard = new List<Habitacion>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC sp_obtener_habitaciones {idTarifa}";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Habitacion h = new Habitacion();

                            h.id_habitacion = Convert.ToInt32(dataReader["id"]);
                            h.estado = Convert.ToInt32(dataReader["estado"]);
                            habitacionesStandard.Add(h);

                        }

                    }
                }
                connection.Close();
            }
            return habitacionesStandard;
        }
    }
}
