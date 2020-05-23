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

    }
}