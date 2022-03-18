using Microsoft.AspNetCore.Mvc;
using MvcApiSeriesPersonajesDpr.Models;
using MvcApiSeriesPersonajesDpr.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiSeriesPersonajesDpr.Controllers
{
    public class ApiServidorController : Controller
    {
        private ApiSeriesPersonajesService service;
        public ApiServidorController(ApiSeriesPersonajesService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Serie> series = await this.service.GetSeriesAsync();
            List<Personaje> person = await this.service.GetPersonajesAsync();
            ViewBag.person = person;
            return View(series);
        }

        public async Task<IActionResult> DetallesSerie(int idSerie)
        {
            Serie s = await this.service.GetSerieDetailAsync(idSerie);
            return View(s);
        }
        public async Task<IActionResult> PersonajesSerie(int idSerie)
        {
            List<Personaje> p = await this.service.GetPersonajesSerieAsync(idSerie);
            ViewBag.idserie = idSerie;
            return View(p);
        }

        public IActionResult InsertarPersonaje(int idSerie)
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertarPersonaje(int IdPersonaje, String NombrePersonaje, String Imagen, int IdSerie)
        {
            await this.service.InsertPersonajeAsync(IdPersonaje, NombrePersonaje, Imagen, IdSerie);
            return View();
        }

        public IActionResult EditarSerie(int idSerie)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditarSerie(int IdSerie, string NombreSerie
            , String Imagen, double Puntuacion, int Año)
        {
            Debug.WriteLine(IdSerie);
            await this.service.UpdateSerieAsync(IdSerie, NombreSerie, Imagen, Puntuacion, Año);

            return View();
        }

        public async Task<IActionResult> DeletePersonaje(int idPersonaje, int idSerie)
        {
            await this.service.DeletePersonajeAsync(idPersonaje);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MoverPersonaje(int IdPersonaje, int IdSerie)
        {
            await this.service.UpdatePersonajeSerieAsync(IdSerie, IdPersonaje);
            return RedirectToAction("Index");
        }










    }
}
