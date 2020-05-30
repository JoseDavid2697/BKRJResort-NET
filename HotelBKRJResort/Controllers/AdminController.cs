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
using System.Web;
using System.IO;

namespace HotelBKRJResort.Controllers
{
    public class AdminController : Controller
    {
        public IConfiguration Configuration { get; }

        public AdminController(IConfiguration configuration)
        {
            this.Configuration = configuration;
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


        [HttpPost]
        public IActionResult RegistrarTemporada(String nombre, String fechaInicio, String fechaFin, float multiplicador)
        {
            TemporadaBusiness temporadaBusiness = new TemporadaBusiness(this.Configuration);

            List<Temporada> temporadas = temporadaBusiness.RegistrarTemporada(nombre, fechaInicio, fechaFin, multiplicador);

            return View("Temporadas", temporadas);
        }

        [HttpPost]
        public IActionResult RegistrarOferta(String nombre, String descripcion, String linkDestino)
        {
            OfertaBusiness ofertaBusiness = new OfertaBusiness(this.Configuration);

            List<Oferta> ofertas = ofertaBusiness.RegistrarOferta(nombre, descripcion, linkDestino);

            return View("Ofertas", ofertas);
        }


        [HttpPost]
        public IActionResult ActualizarTemporada(int id, String nombre, String fechaInicio, String fechaFin, float multiplicador)
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

        public IActionResult ConsultarHabitacion()
        {
            return View("ConsultarHabitacion", null);
        }

        [HttpPost]
        public IActionResult  ResultadoConsultarHabitacion(String fecha_llegada, String fecha_salida, int tipo_habitacion)
        {
            HabitacionBusiness habitacionBusiness = new HabitacionBusiness(this.Configuration);

            List<Habitacion> habitaciones = habitacionBusiness.obtenerDisponibilidadHabitaciones(fecha_llegada,fecha_salida,tipo_habitacion);

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
            return View("AdministrarHabitaciones");
        }

        public IActionResult CambiarDescripcionStandard()
        {
            TarifaBusiness tb = new TarifaBusiness(this.Configuration);

            return View("CambiarDescripcionStandard",tb.ObtenerTarifaStandard());
        }

        public IActionResult CambiarDescripcionJunior()
        {
            TarifaBusiness tb = new TarifaBusiness(this.Configuration);

            return View("CambiarDescripcionJunior", tb.ObtenerTarifaJunior());
        }

        public IActionResult ActualizarTarifa(int id, int precio, String descripcion)
        {
            String mensaje = "Actualizado con exito";
            try
            {
                TarifaBusiness tb = new TarifaBusiness(this.Configuration);
                tb.ActualizarTarifa(id, precio, descripcion);
            }
            catch {
                mensaje = "Error al actualizar";
            }
            

            return View("AdministrarHabitaciones", mensaje);
        }
        
    }
}