using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelBKRJResort.Models;
using Microsoft.Extensions.Configuration;
using HotelBKRJResort.Models.Business;
using Newtonsoft.Json;


namespace HotelBKRJResort.Controllers
{
    public class HomeController : Controller
    {

        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IActionResult Index()
        {

            OfertaBusiness ofertaBusiness = new OfertaBusiness(this.Configuration);

            ObjetoContenedorPrincipal contenedor = new ObjetoContenedorPrincipal();

            contenedor.Ofertas = ofertaBusiness.ObtenerOfertas();

            return View("Index", contenedor);
        }

        public IActionResult SobreNosotros()
        {
            VistaBusiness vb = new VistaBusiness(this.Configuration);

            return View("SobreNosotros", vb.obtenerSobreNosotros());
        }

        public IActionResult Facilidades()
        {
            return View();
        }

        public IActionResult ComoLlegar()
        {

            return View();
        }

        public IActionResult Tarifas()
        {

            TarifaBusiness tarifaBusiness = new TarifaBusiness(this.Configuration);

            ObjetoContenedorPrincipal contenedor = new ObjetoContenedorPrincipal();

            contenedor.Tarifas = tarifaBusiness.ObtenerTarifas();

            return View("Tarifas", contenedor);
        }

        public IActionResult ReservasEnLinea()
        {

            return View();
        }

        public IActionResult Contactenos()
        {

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //Valida si una habitacion esta disponible en las fechas indicadas
        [HttpPost]
        public IActionResult ValidarReservacion(String fecha_llegada, String fecha_salida, int tipo_habitacion)
        {
            ReservacionBusiness reservacionBusiness = new ReservacionBusiness(this.Configuration);

            ObjetoContenedorPrincipal contenedor = new ObjetoContenedorPrincipal();

            contenedor.Habitacion = reservacionBusiness.ValidarReservacion(fecha_llegada, fecha_salida, tipo_habitacion);


            return View("ResultadoHabitacion", contenedor);
        }
        [HttpPost]
        public string obtenerUsuario(String identificacion)
        {
            ReservacionBusiness reservacionBusiness = new ReservacionBusiness(this.Configuration);
            Usuario u = reservacionBusiness.obtenerUsuario(identificacion);
            string output = JsonConvert.SerializeObject(u);
            return output;

        }

    }
}
