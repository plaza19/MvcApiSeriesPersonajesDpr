using Microsoft.Extensions.Configuration;
using MvcApiSeriesPersonajesDpr.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcApiSeriesPersonajesDpr.Services
{
    public class ApiSeriesPersonajesService
    {
        private Uri UriApi;
        private MediaTypeWithQualityHeaderValue Header;
        public ApiSeriesPersonajesService(IConfiguration configuration)
        {
            String url = configuration.GetConnectionString("cadenaapi");
            this.UriApi = new Uri(url);
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            string request = "/api/Series";
            List<Serie> series =
                await this.CallApiAsync<List<Serie>>(request);
            return series;
        }

        public async Task<Serie> GetSerieDetailAsync(int idSerie)
        {
            string request = "/api/Series/" + idSerie;
            Serie serie =
                await this.CallApiAsync<Serie>(request);
            return serie;
        }

        public async Task<List<Personaje>> GetPersonajesSerieAsync(int idSerie)
        {
            string request = "/api/Personajes/" + idSerie;
            List<Personaje> personaje =
                await this.CallApiAsync<List<Personaje>>(request);
            return personaje;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            string request = "/api/Personajes";
            List<Personaje> personaje =
                await this.CallApiAsync<List<Personaje>>(request);
            return personaje;
        }


        public async Task InsertPersonajeAsync
            (int IdPersonaje, String NombrePersonaje, String Imagen, int IdSerie)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/Personajes";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Personaje p = new Personaje();
                p.IdPersonaje = IdPersonaje;
                p.NombrePersonaje = NombrePersonaje;
                p.Imagen = Imagen;
                p.IdSerie = IdSerie;
                string json = JsonConvert.SerializeObject(p);
  
                StringContent content = new StringContent
                    (json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(request, content);
            }
        }

        public async Task UpdateSerieAsync(int IdSerie, string NombreSerie
            , String Imagen, double Puntuacion, int Año)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/Series";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Serie s = new Serie();
                s.Año = Año;
                s.IdSerie = IdSerie;
                s.Imagen = Imagen;
                s.NombreSerie = NombreSerie;
                s.Puntuacion = Puntuacion;

                
                string json = JsonConvert.SerializeObject(s);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PutAsync(request, content);
            }
        }

        public async Task DeletePersonajeAsync(int idPersonaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/Personajes/" + idPersonaje;
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.DeleteAsync(request);
            }
        }

        public async Task UpdatePersonajeSerieAsync(int IdSerie, int IdPersonaje)
        {
            Debug.WriteLine(IdSerie);
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/Personajes/" + IdPersonaje + "/" + IdSerie;
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
            

                string json = JsonConvert.SerializeObject("");
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PutAsync(request, content);
            }
        }



    }
}
