using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Data
{

    public class ReservacionData
    {
        public IConfiguration Configuration { get; }

        public ReservacionData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Habitacion ValidarReservacion(String fecha_llegada, String fecha_salida, int tipo_habitacion)
        {

            Habitacion habitacion = new Habitacion();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtenerHabitacionDisponible]'{fecha_llegada}','{fecha_salida}',{tipo_habitacion}";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {

                        dataReader.Read();
                        if (Convert.ToInt32(dataReader["resultado"]) != 0)
                        {
                            habitacion.id_habitacion = Convert.ToInt32(dataReader["id"]);
                            habitacion.monto = Convert.ToInt32(dataReader["monto"]);
                            habitacion.descripcion = dataReader["descripcion"].ToString();
                            habitacion.imagen = dataReader["imagen"].ToString();
                            habitacion.resultado = Convert.ToInt32(dataReader["resultado"]);
                            habitacion.fecha_inicio = dataReader["inicio"].ToString();
                            habitacion.fecha_final = dataReader["final"].ToString();
                        }
                        else
                        {
                            habitacion.resultado = Convert.ToInt32(dataReader["resultado"]);
                        }

                    }
                    connection.Close();
                }

                return habitacion;
            }
        }

        public void InsertarReservacion(Reservacion reservacion)
        {

            

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_insertar_reserva]{reservacion.id_habitacion},{reservacion.monto},'{reservacion.fecha_inicio.ToString("yyyy-MM-dd")}','{reservacion.fecha_final.ToString("yyyy-MM-dd")}','{reservacion.nombre}','{reservacion.apellidos}','{reservacion.email}','{reservacion.tarjeta}','{reservacion.codigo}','{reservacion.identificacion}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        
         public List<Reservacion> ObtenerReservaciones()
        {

            List<Reservacion> reservaciones = new List<Reservacion>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtener_reservaciones]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            Reservacion reservacion = new Reservacion();
                            reservacion.codigo = Convert.ToString(dataReader["codigo"]);
                            reservacion.nombre = Convert.ToString(dataReader["nombreCliente"]);
                            reservacion.apellidos = Convert.ToString(dataReader["apellidosCliente"]);
                            reservacion.email = Convert.ToString(dataReader["coreoCliente"]);
                            reservacion.tarjeta = Convert.ToString(dataReader["cuentaCliente"]);
                            reservacion.id = Convert.ToInt32(dataReader["id"]);
                            reservacion.fecha_inicio = Convert.ToDateTime(dataReader["fechaInicio"]);
                            reservacion.fecha_final = Convert.ToDateTime(dataReader["fechaFinal"]);
                            reservacion.tipoHabitacion = Convert.ToString(dataReader["nombre"]);
                            
                            reservaciones.Add(reservacion);
                        }
                    }
                }
                connection.Close();
            }
            return reservaciones;
        }

        public Usuario obtenerUsuario(String identificacion)
        {

            Usuario usuario = new Usuario();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"EXEC [dbo].[sp_obtener_datos_usuario]'{identificacion}'";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {

                        dataReader.Read();
                        if (Convert.ToInt32(dataReader["resultado"]) != 0)
                        {
                            usuario.nombre = dataReader["nombreCliente"].ToString();
                            usuario.apellidos = dataReader["apellidosCliente"].ToString();
                            usuario.email = dataReader["coreoCliente"].ToString();
                            usuario.tarjeta = dataReader["cuentaCliente"].ToString();
                            
                        }
                    }
                    connection.Close();
                }
                return usuario;
            }
        }
        
    }
}
