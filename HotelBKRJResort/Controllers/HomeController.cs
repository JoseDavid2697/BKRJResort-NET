using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelBKRJResort.Models;

namespace HotelBKRJResort.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SobreNosotros()
        {

            return View();
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

            return View();
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
    }
}
