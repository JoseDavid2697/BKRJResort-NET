using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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
                            oferta.Nombre = Convert.ToString(dataReader["nombre"]);
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

        public List<Oferta> ObtenerOfertasSolicitadas()
        {

            List<Oferta> ofertas = new List<Oferta>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtener_ofertas_solicitadas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Oferta oferta = new Oferta();
                            oferta.Id = Convert.ToInt32(dataReader["id"]);
                            oferta.Nombre = Convert.ToString(dataReader["nombre"]);
                            oferta.Descripcion = Convert.ToString(dataReader["descripcion"]);
                            oferta.Imagen = Convert.ToString(dataReader["imagen"]);
                            oferta.Link_Destino = Convert.ToString(dataReader["link_destino"]);
                            oferta.NombreProveedor = Convert.ToString(dataReader["usuario"]);

                            ofertas.Add(oferta);
                        }

                    }
                }
                connection.Close();
            }

            return ofertas;
        }

        public List<Oferta> ObtenerOfertasAdmin()
        {
            List<Oferta> ofertas = new List<Oferta>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtener_todas_ofertas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Oferta oferta = new Oferta();
                            oferta.Id = Convert.ToInt32(dataReader["id"]);
                            oferta.Nombre = Convert.ToString(dataReader["nombre"]);
                            oferta.Descripcion = Convert.ToString(dataReader["descripcion"]);
                            oferta.Link_Destino = Convert.ToString(dataReader["link_destino"]);


                            ofertas.Add(oferta);
                        }

                    }
                }
                connection.Close();
            }

            return ofertas;
        }

        public List<Oferta> RegistrarOferta(String nombre, String descripcion, String linkDestino, string img)
        {

            List<Oferta> ofertas = new List<Oferta>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (var connection = new SqlConnection(connectionString))
            {


                string sql = $"EXEC [dbo].[sp_insertar_oferta]'{nombre}','{descripcion}','/assets/img/promociones/{img}','{linkDestino}',1,NULL";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                connection.Open();
                sql = $"EXEC [dbo].[sp_obtener_todas_ofertas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Oferta oferta = new Oferta();
                            oferta.Id = Convert.ToInt32(dataReader["id"]);
                            oferta.Nombre = Convert.ToString(dataReader["nombre"]);
                            oferta.Descripcion = Convert.ToString(dataReader["descripcion"]);
                            oferta.Link_Destino = Convert.ToString(dataReader["link_destino"]);

                            ofertas.Add(oferta);
                        }

                    }
                }
                connection.Close();
            }

            return ofertas;
        }

        public List<Oferta> ActualizarOferta(int id, String nombre, String descripcion, String linkDestino)
        {

            List<Oferta> ofertas = new List<Oferta>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (var connection = new SqlConnection(connectionString))
            {

                string sql = $"EXEC [dbo].[sp_actualizar_oferta]'{id}','{nombre}','{descripcion}','{linkDestino}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                connection.Open();
                sql = $"EXEC [dbo].[sp_obtener_todas_ofertas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Oferta oferta = new Oferta();
                            oferta.Id = Convert.ToInt32(dataReader["id"]);
                            oferta.Nombre = Convert.ToString(dataReader["nombre"]);
                            oferta.Descripcion = Convert.ToString(dataReader["descripcion"]);
                            oferta.Link_Destino = Convert.ToString(dataReader["link_destino"]);

                            ofertas.Add(oferta);
                        }
                    }
                }
                connection.Close();
            }
            return ofertas;
        }
        public List<Oferta> EliminarOferta(int id)
        {

            List<Oferta> ofertas = new List<Oferta>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (var connection = new SqlConnection(connectionString))
            {

                string sql = $"EXEC [dbo].[sp_eliminar_oferta]'{id}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                connection.Open();
                sql = $"EXEC [dbo].[sp_obtener_todas_ofertas]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Oferta oferta = new Oferta();
                            oferta.Id = Convert.ToInt32(dataReader["id"]);
                            oferta.Nombre = Convert.ToString(dataReader["nombre"]);
                            oferta.Descripcion = Convert.ToString(dataReader["descripcion"]);
                            oferta.Link_Destino = Convert.ToString(dataReader["link_destino"]);


                            ofertas.Add(oferta);
                        }

                    }
                }
                connection.Close();
            }
            return ofertas;
        }

        public void AceptarOferta(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (var connection = new SqlConnection(connectionString))
            {


                string sql = $"EXEC [dbo].[sp_aceptar_oferta] {id}";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        public string ObtenerCorreoProveedor(int id)
        {

            string correo = "";

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC sp_obtener_correo_proveedor {id}";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        dataReader.Read();
                       correo =  Convert.ToString(dataReader["correo"]);

                    }
                }
                connection.Close();
            }

            return correo;
        }
    }
}
