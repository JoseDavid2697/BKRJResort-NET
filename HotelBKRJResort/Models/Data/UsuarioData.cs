using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Data
{

    public class UsuarioData
    {
        public IConfiguration Configuration { get; }

        public UsuarioData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public int ValidarUsuario(String usuario, String contra)
        {
            
            int resultado = 0;

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_validarusuario]'{usuario}','{contra}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {

                        dataReader.Read();
                        if (Convert.ToInt32(dataReader["resultado"]) != 0)
                        {
                            resultado = 1;
                        }

                    }
                    connection.Close();
                }

                return resultado;
            }
        }
        
    }
}
