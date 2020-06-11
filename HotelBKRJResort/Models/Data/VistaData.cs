using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Data
{

    public class VistaData
    {
        public IConfiguration Configuration { get; }

        public VistaData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Vista obtenerSobreNosotros()
        {
            Vista vista = new Vista();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtenerSobreNosotros]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                           
                            vista.titulo = Convert.ToString(dataReader["titulo"]);
                            vista.descripcion = Convert.ToString(dataReader["descripcion"]);
                            vista.reconocimientos = Convert.ToString(dataReader["reconocimientos"]);
                            vista.alianzas = Convert.ToString(dataReader["alianzas"]);
                            vista.experiencias = Convert.ToString(dataReader["experiencias"]);
                            vista.seguridad = Convert.ToString(dataReader["seguridad"]);

                        }

                    }
                }
                connection.Close();
            }

            return vista;
        }

        public Vista actualizarSobreNosotros(Vista vista)
        {
            Vista vistaActualizada = new Vista();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = $"EXEC [dbo].[sp_actualizar_sobreNosotros]'{vista.titulo}','{vista.descripcion}','{vista.reconocimientos}','{vista.alianzas}','{vista.experiencias}','{vista.seguridad}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                connection.Open();

                sql = $"EXEC [dbo].[sp_obtenerSobreNosotros]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            vistaActualizada.titulo = Convert.ToString(dataReader["titulo"]);
                            vistaActualizada.descripcion = Convert.ToString(dataReader["descripcion"]);
                            vistaActualizada.reconocimientos = Convert.ToString(dataReader["reconocimientos"]);
                            vistaActualizada.alianzas = Convert.ToString(dataReader["alianzas"]);
                            vistaActualizada.experiencias = Convert.ToString(dataReader["experiencias"]);
                            vistaActualizada.seguridad = Convert.ToString(dataReader["seguridad"]);

                        }

                    }
                }
                connection.Close();
            }

            return vistaActualizada;
        }

        public Vista obtenerComoLlegar()
        {
            Vista vista = new Vista();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtenerComoLlegar]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            vista.titulo = Convert.ToString(dataReader["titulo"]);
                            vista.descripcion = Convert.ToString(dataReader["descripcion"]);

                        }

                    }
                }
                connection.Close();
            }

            return vista;
        }

        public Vista actualizarComoLlegar(Vista vista)
        {
            Vista vistaActualizada = new Vista();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = $"EXEC [dbo].[sp_actualizar_comollegar]'{vista.titulo}','{vista.descripcion}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                connection.Open();

                sql = $"EXEC [dbo].[sp_obtenerComoLlegar]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            vistaActualizada.titulo = Convert.ToString(dataReader["titulo"]);
                            vistaActualizada.descripcion = Convert.ToString(dataReader["descripcion"]);

                        }

                    }
                }
                connection.Close();
            }

            return vistaActualizada;
        }


    }
}
