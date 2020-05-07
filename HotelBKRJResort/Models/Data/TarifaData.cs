using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
    }
}
