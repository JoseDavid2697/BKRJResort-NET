using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Data
{
    public class OfertaData
    {
        public IConfiguration Configuration { get; }

        public OfertaData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Oferta> ObtenerOfertas()
        {

            List<Oferta> ofertas = new List<Oferta>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtener_ofertas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Oferta oferta = new Oferta();
                            oferta.Id = Convert.ToInt32(dataReader["id"]);
                            oferta.Nombre= Convert.ToString(dataReader["nombre"]);
                            oferta.Descripcion = Convert.ToString(dataReader["descripcion"]);
                            oferta.Imagen = Convert.ToString(dataReader["imagen"]);
                            oferta.Link_Destino = Convert.ToString(dataReader["link_destino"]);


                            ofertas.Add(oferta);
                        }

                    }
                }
                connection.Close();
            }

            return ofertas;
        }

    }
}
