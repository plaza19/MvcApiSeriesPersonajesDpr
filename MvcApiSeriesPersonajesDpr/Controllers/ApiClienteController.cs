using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiSeriesPersonajesDpr.Controllers
{
    public class ApiClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Personajes(int idSerie)
        {
            return View();
        }

        public IActionResult EliminarSerie(int idSerie)
        {
            return View();
        }
    }
}
