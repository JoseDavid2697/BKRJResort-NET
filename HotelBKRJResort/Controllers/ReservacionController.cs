using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HotelBKRJResort.Models;
using HotelBKRJResort.Models.Business;
using HotelBKRJResort.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HotelBKRJResort.Controllers
{
    public class ReservacionController : Controller
    {
        public IConfiguration Configuration { get; }

        public ReservacionController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        //Inserta una nueva reservacion
        [HttpPost]
        public IActionResult insertarReservacion(Reservacion reservacion)
        {
            MensajeReserva mr = new MensajeReserva();
            mr.nombre = reservacion.nombre;
            mr.email = reservacion.email;

            mr.codigo = "RE-" + reservacion.nombre.Substring(0, 3) + "-" + reservacion.id_habitacion;
            reservacion.codigo = mr.codigo;
            ReservacionBusiness rb = new ReservacionBusiness(this.Configuration);
            rb.insertarReservacion(reservacion);

            ObjetoContenedorPrincipal contenedor = new ObjetoContenedorPrincipal();
            contenedor.mensaje = mr;

            String bodyParam = "Su reservacion en el hotel BKRJ Resort se ha completado,\n Su numero de reservacion es: "+mr.codigo+"\nGracias por preferirnos!";
            enviarCorreo(mr.email,bodyParam);
            return View("ConfirmarReservacion",contenedor);
           
        }


        public void enviarCorreo(string correo_cliente, string bodyParam)
        {
            try
            {
                string usuarioCorreo = Configuration["ConnectionStrings:UsuarioCorreo"];
                string contrasennaCorreo = Configuration["ConnectionStrings:ContrasennaCorreo"];

                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress(usuarioCorreo, "BKRJ Resort");
                    var receiverEmail = new MailAddress(correo_cliente, "Cliente");
                    var password = contrasennaCorreo;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = "Reservacion en BKRJ Resort",
                        Body = bodyParam
                    })
                    {
                        smtp.Send(mess);
                        System.Diagnostics.Debug.WriteLine("Enviado");
                    }
                }
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e);
            }

        }
    }
}