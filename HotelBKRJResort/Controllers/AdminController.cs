using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelBKRJResort.Models;
using HotelBKRJResort.Models.Business;
using HotelBKRJResort.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Rotativa.AspNetCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mail;
using System.Net;

namespace HotelBKRJResort.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public IConfiguration Configuration { get; }

        public AdminController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this.Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }


        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult Temporadas()
        {
            TemporadaBusiness temporadaBusiness = new TemporadaBusiness(this.Configuration);

            List<Temporada> temporadas = temporadaBusiness.ObtenerTemporadas();

            return View("Temporadas", temporadas);
        }
        public IActionResult listadoReservaciones()
        {
            ReservacionBusiness reservacionBusiness = new ReservacionBusiness(this.Configuration);

            List<Reservacion> reservacions = reservacionBusiness.ObtenerReservaciones();

            return View("Reservaciones", reservacions);
        }

        [HttpPost]
        public IActionResult verReservacion(Reservacion reservacion)
        {


            return View("ReservacionIndividual", reservacion);
        }
        [HttpPost]
        public IActionResult eliminarReservacion(int id)
        {
            ReservacionBusiness reservacionBusiness = new ReservacionBusiness(this.Configuration);

            reservacionBusiness.EliminarReservacion(id);

            List<Reservacion> reservacions = reservacionBusiness.ObtenerReservaciones();

            return View("Reservaciones", reservacions);
        }

        [HttpPost]
        public IActionResult ImprimirReserva(Reservacion r)
        {
            return new ViewAsPdf("ReporteReserva", r);
        }


        [HttpPost]
        public IActionResult RegistrarTemporada(String nombre, String fechaInicio, String fechaFin, String multiplicador)
        {
            TemporadaBusiness temporadaBusiness = new TemporadaBusiness(this.Configuration);

            List<Temporada> temporadas = temporadaBusiness.RegistrarTemporada(nombre, fechaInicio, fechaFin, multiplicador);

            return View("Temporadas", temporadas);
        }

        [HttpPost]
        public IActionResult RegistrarOferta(String nombre, String descripcion, String linkDestino, IFormFile img)
        {
            OfertaBusiness ofertaBusiness = new OfertaBusiness(this.Configuration);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/promociones");
            var filePath = Path.Combine(uploads, img.FileName);
            img.CopyTo(new FileStream(filePath, FileMode.Create));

            List<Oferta> ofertas = ofertaBusiness.RegistrarOferta(nombre, descripcion, linkDestino, img.FileName);

            return View("Ofertas", ofertas);
        }


        [HttpPost]
        public IActionResult ActualizarTemporada(int id, String nombre, String fechaInicio, String fechaFin, String multiplicador)
        {
            System.Diagnostics.Debug.WriteLine(id);
            System.Diagnostics.Debug.WriteLine(nombre);
            System.Diagnostics.Debug.WriteLine(multiplicador);
            TemporadaBusiness temporadaBusiness = new TemporadaBusiness(this.Configuration);

            List<Temporada> temporadas = temporadaBusiness.ActualizarTemporada(id, nombre, fechaInicio, fechaFin, multiplicador);

            return View("Temporadas", temporadas);
        }


        [HttpPost]
        public IActionResult EliminarTemporada(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            TemporadaBusiness temporadaBusiness = new TemporadaBusiness(this.Configuration);

            List<Temporada> temporadas = temporadaBusiness.EliminarTemporada(id);

            return View("Temporadas", temporadas);
        }
        [HttpPost]
        public IActionResult EliminarOferta(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            OfertaBusiness ofertaBusiness = new OfertaBusiness(this.Configuration);

            List<Oferta> ofertas = ofertaBusiness.EliminarOferta(id);

            return View("Ofertas", ofertas);
        }

        public IActionResult Ofertas()
        {
            return View();
        }
        public IActionResult OfertasAdmin()
        {
            OfertaBusiness ofertaBusiness = new OfertaBusiness(this.Configuration);

            List<Oferta> ofertas = ofertaBusiness.ObtenerOfertasAdmin();

            return View("Ofertas", ofertas);
        }
        [HttpPost]
        public IActionResult ActualizarOfertas(int id, String nombre, String descripcion, String linkDestino)
        {

            OfertaBusiness ofertaBusiness = new OfertaBusiness(this.Configuration);

            List<Oferta> ofertas = ofertaBusiness.ActualizarOferta(id, nombre, descripcion, linkDestino);

            return View("Ofertas", ofertas);
        }
        [HttpPost]
        public IActionResult ValidarUsuario(String usuario, String contra)
        {
            UsuarioBusiness usuarioBusiness = new UsuarioBusiness(this.Configuration);

            int resultado = usuarioBusiness.ValidarUsuario(usuario, contra);
            if (resultado == 1)
            {
                OfertaBusiness ofertaBusiness = new OfertaBusiness(this.Configuration);

                ObjetoContenedorPrincipal contenedor = new ObjetoContenedorPrincipal();

                contenedor.Ofertas = ofertaBusiness.ObtenerOfertas();

                return View("Admin", contenedor);
            }

            return View("LogIn");
        }

        public IActionResult Index()
        {
            OfertaBusiness ofertaBusiness = new OfertaBusiness(this.Configuration);

            ObjetoContenedorPrincipal contenedor = new ObjetoContenedorPrincipal();

            contenedor.Ofertas = ofertaBusiness.ObtenerOfertas();

            return View("Admin", contenedor);
        }


        public IActionResult verificarEstadoHabitaciones()
        {
            HabitacionBusiness habitacionBusiness = new HabitacionBusiness(this.Configuration);

            List<Habitacion> habitaciones = habitacionBusiness.obtenerEstadoHabitaciones();


            return View("Habitaciones", habitaciones);
        }

        public IActionResult ImprimirHabitaciones()
        {
            HabitacionBusiness habitacionBusiness = new HabitacionBusiness(this.Configuration);

            List<Habitacion> habitaciones = habitacionBusiness.obtenerEstadoHabitaciones();

            return new ViewAsPdf("ReporteHabitaciones", habitaciones);

        }

        public IActionResult ConsultarHabitacion()
        {
            return View("ConsultarHabitacion", null);
        }

        [HttpPost]
        public IActionResult ResultadoConsultarHabitacion(String fecha_llegada, String fecha_salida, int tipo_habitacion)
        {
            HabitacionBusiness habitacionBusiness = new HabitacionBusiness(this.Configuration);

            List<Habitacion> habitaciones = habitacionBusiness.obtenerDisponibilidadHabitaciones(fecha_llegada, fecha_salida, tipo_habitacion);

            int res = 0;
            foreach (var item in habitaciones)
            {
                res = item.resultado;
            }

            if (res == 0)
            {
                return View("ConsultarHabitacion", null);
            }
            else
            {
                return View("ConsultarHabitacion", habitaciones);
            }

        }

        public IActionResult AdministrarHabitaciones()
        {
            TarifaBusiness tb = new TarifaBusiness(this.Configuration);

            ObjetoContenedorPrincipal obj = new ObjetoContenedorPrincipal();
            obj.HabitacionesStandard = tb.ObtenerHabitaciones(1);
            obj.HabitacionesJunior = tb.ObtenerHabitaciones(2);

            return View("AdministrarHabitaciones", obj);
        }

        public IActionResult CambiarDescripcionStandard()
        {
            TarifaBusiness tb = new TarifaBusiness(this.Configuration);

            return View("CambiarDescripcionStandard", tb.ObtenerTarifaStandard());
        }

        public IActionResult CambiarDescripcionJunior()
        {
            TarifaBusiness tb = new TarifaBusiness(this.Configuration);

            return View("CambiarDescripcionJunior", tb.ObtenerTarifaJunior());
        }

        public IActionResult ActualizarTarifa(int id, int precio, String descripcion, IFormFile img)
        {


            if (img != null)
            {
                var fileName = "";
                if (id == 2)
                {
                    fileName = "junior.jpg";
                }
                else if (id == 1)
                {
                    fileName = "standard.jpg";
                }

                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/tarifas");
                var filePath = Path.Combine(uploads, fileName);
                FileStream f = new FileStream(filePath, FileMode.Create);
                img.CopyTo(f);
                f.Close();


            }
            TarifaBusiness tb = new TarifaBusiness(this.Configuration);
            String mensaje = "Actualizado con exito";
            try
            {

                tb.ActualizarTarifa(id, precio, descripcion);
            }
            catch
            {
                mensaje = "Error al actualizar";
            }

            ObjetoContenedorPrincipal obj = new ObjetoContenedorPrincipal();
            obj.HabitacionesStandard = tb.ObtenerHabitaciones(1);
            obj.HabitacionesJunior = tb.ObtenerHabitaciones(2);
            obj.Mensaje = mensaje;

            return View("AdministrarHabitaciones", obj);
        }

        [HttpPost]
        public void actualizarEstado(int idHabitacion, int estado)
        {
            HabitacionBusiness hb = new HabitacionBusiness(this.Configuration);
            hb.actualizarEstado(idHabitacion, estado);

        }

        //--------------ACTUALIZAR VISTAS--------------

        public IActionResult SobreNosotros()
        {
            VistaBusiness vb = new VistaBusiness(this.Configuration);

            return View("SobreNosotrosEditable", vb.obtenerSobreNosotros());
        }

        public IActionResult ActualizarSobreNosotros(Vista vista)
        {
            VistaBusiness vb = new VistaBusiness(this.Configuration);

            return View("SobreNosotrosEditable", vb.actualizarSobreNosotros(vista));
        }

        public IActionResult Facilidades()
        {
            VistaBusiness vb = new VistaBusiness(this.Configuration);

            return View("FacilidadesEditable", vb.obtenerFacilidades());
        }

        public IActionResult ActualizarFacilidades(Vista vista)
        {
            VistaBusiness vb = new VistaBusiness(this.Configuration);

            return View("FacilidadesEditable", vb.actualizarFacilidades(vista));
        }

        public IActionResult ComoLlegar()
        {
            VistaBusiness vb = new VistaBusiness(this.Configuration);

            return View("ComoLlegarEditable", vb.obtenerComoLlegar());
        }

        public IActionResult ActualizarComoLlegar(Vista vista)
        {
            VistaBusiness vb = new VistaBusiness(this.Configuration);

            return View("ComoLlegarEditable", vb.actualizarComoLlegar(vista));
        }

        public IActionResult Home()
        {
            VistaBusiness vb = new VistaBusiness(this.Configuration);

            return View("HomeEditable", vb.obtenerHome());
        }

        public IActionResult ActualizarHome(Vista vista, IFormFile img1, IFormFile img2, IFormFile img3)
        {
            VistaBusiness vb = new VistaBusiness(this.Configuration);

            if (img1 != null)
            {
                var fileName = "slide-1.jpg";
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/slide");
                var filePath = Path.Combine(uploads, fileName);
                FileStream f = new FileStream(filePath, FileMode.Create);
                img1.CopyTo(f);
                f.Close();
            }

            if (img2 != null)
            {
                var fileName = "slide-2.jpg";
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/slide");
                var filePath = Path.Combine(uploads, fileName);
                FileStream f = new FileStream(filePath, FileMode.Create);
                img2.CopyTo(f);
                f.Close();

            }

            if (img3 != null)
            {
                var fileName = "slide-3.jpg";

                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/slide");
                var filePath = Path.Combine(uploads, fileName);
                FileStream f = new FileStream(filePath, FileMode.Create);
                img3.CopyTo(f);
                f.Close();


            }


            return View("HomeEditable", vb.actualizarHome(vista));
        }

        public IActionResult MostrarOfertasSolicitadas()
        {
            OfertaBusiness ob = new OfertaBusiness(this.Configuration);


            return View("SolicitudesOfertas", ob.ObtenerOfertasSolicitadas());
        }

        public IActionResult ResponderSolicitudOferta(int id, int opcion)
        {
            OfertaBusiness ob = new OfertaBusiness(this.Configuration);
            string mensaje = "";
            string correo = ob.ObtenerCorreoProveedor(id);
            if (opcion == 0)
            {
                ob.EliminarOferta(id);
                mensaje = "Su solicitud de publicar la oferta número " + id + " fue RECHAZADA y eliminada por los administradores de BKRJ Resort";
                enviarCorreo(correo, mensaje);
            }
            else if (opcion == 1)
            {
                ob.AceptarOferta(id);
                mensaje = "Su solicitud de publicar la oferta número " + id + " fue ACEPTADA por los administradores de BKRJ Resort";
                enviarCorreo(correo, mensaje);
            }


            return View("SolicitudesOfertas", ob.ObtenerOfertasSolicitadas());
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
                    var receiverEmail = new MailAddress(correo_cliente, "Proveedor");
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
                        Subject = "Solicitud de publicación de oferta",
                        Body = bodyParam
                    })
                    {
                        smtp.Send(mess);
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