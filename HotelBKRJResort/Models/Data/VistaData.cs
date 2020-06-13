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

        //-------------SOBRE NOSOTROS-------------
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
      
     
        //-------------COMO LLEGAR-------------
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
      
        //-------------FACILIDADES-------------

        public Vista obtenerFacilidades()
        {
            Vista vista = new Vista();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtenerFacilidades]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            vista.equipo = Convert.ToString(dataReader["equipo"]);
                            vista.precios = Convert.ToString(dataReader["precios"]);
                            vista.internet = Convert.ToString(dataReader["internet"]);
                            vista.mirador = Convert.ToString(dataReader["mirador"]);
                            vista.seguridad = Convert.ToString(dataReader["seguridad"]);
                            vista.calendarios = Convert.ToString(dataReader["calendarios"]);

                        }

                    }
                }
                connection.Close();
            }

            return vista;
        }

        public Vista actualizarFacilidades(Vista vista)
        {
            Vista vistaActualizada = new Vista();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = $"EXEC [dbo].[sp_actualizar_facilidades]'{vista.equipo}','{vista.precios}','{vista.internet}','{vista.mirador}','{vista.seguridad}','{vista.calendarios}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                connection.Open();

                sql = $"EXEC [dbo].[sp_obtenerFacilidades]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            vistaActualizada.equipo = Convert.ToString(dataReader["equipo"]);
                            vistaActualizada.precios = Convert.ToString(dataReader["precios"]);
                            vistaActualizada.internet = Convert.ToString(dataReader["internet"]);
                            vistaActualizada.mirador = Convert.ToString(dataReader["mirador"]);
                            vistaActualizada.seguridad = Convert.ToString(dataReader["seguridad"]);
                            vistaActualizada.calendarios = Convert.ToString(dataReader["calendarios"]);

                        }

                    }
                }
                connection.Close();
            }

            return vistaActualizada;
        }

        public Vista obtenerHome()
        {
            Vista vista = new Vista();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtenerHome]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            vista.texto1 = Convert.ToString(dataReader["texto1"]);
                            vista.texto2 = Convert.ToString(dataReader["texto2"]);
                            vista.texto3 = Convert.ToString(dataReader["texto3"]);
                            vista.imagen1 = Convert.ToString(dataReader["imagen1"]);
                            vista.imagen2 = Convert.ToString(dataReader["imagen2"]);
                            vista.imagen3 = Convert.ToString(dataReader["imagen3"]);
                            vista.descripcion1 = Convert.ToString(dataReader["descripcion1"]);
                            vista.descripcion2 = Convert.ToString(dataReader["descripcion2"]);

                        }

                    }
                }
                connection.Close();
            }

            return vista;
        }

        public Vista actualizarHome(Vista vista)
        {
            Vista vistaActualiza = new Vista();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = $"EXEC [dbo].[sp_actualizar_Home]'{vista.texto1}','{vista.texto2}','{vista.texto3}','{vista.descripcion1}','{vista.descripcion2}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                connection.Open();

                sql = $"EXEC [dbo].[sp_obtenerHome]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            vistaActualiza.texto1 = Convert.ToString(dataReader["texto1"]);
                            vistaActualiza.texto2 = Convert.ToString(dataReader["texto2"]);
                            vistaActualiza.texto3 = Convert.ToString(dataReader["texto3"]);
                            vistaActualiza.imagen1 = Convert.ToString(dataReader["imagen1"]);
                            vistaActualiza.imagen2 = Convert.ToString(dataReader["imagen2"]);
                            vistaActualiza.imagen3 = Convert.ToString(dataReader["imagen3"]);
                            vistaActualiza.descripcion1 = Convert.ToString(dataReader["descripcion1"]);
                            vistaActualiza.descripcion2 = Convert.ToString(dataReader["descripcion2"]);

                        }

                    }
                }
                connection.Close();
            }

            return vistaActualiza;
        }
    }
}
