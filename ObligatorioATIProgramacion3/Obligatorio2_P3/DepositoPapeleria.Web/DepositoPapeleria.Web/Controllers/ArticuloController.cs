using DepositoPapeleria.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DepositoPapeleria.Web.Controllers
{
    public class ArticuloController : Controller
    {
        private HttpClient _cliente;
        private string _urlBase;
        private static int paginaActual;
        private static int _topeMaximoPagina;

        public ArticuloController()
        {
            _cliente = new HttpClient();
            _urlBase = "http://localhost:5141/api";
        }

        public int ObtenerValorConfig()
        {
            if (_topeMaximoPagina == 0)
            {
                // obtener valor config
                HttpRequestMessage solicitudConfig = new HttpRequestMessage(HttpMethod.Get, new Uri($"{_urlBase}/Configuracion/Nombre/TopeMaxPorPagina"));
                Task<HttpResponseMessage> respuestaConfig = _cliente.SendAsync(solicitudConfig);
                respuestaConfig.Wait();
                //obtener valor y guardar si respuesta es exitosa
                if (respuestaConfig.Result.IsSuccessStatusCode)
                {
                    string valorComoTexto = respuestaConfig.Result.Content.ReadAsStringAsync().Result;
                    int valor = Int32.Parse(valorComoTexto);
                    _topeMaximoPagina = valor;
                }
                else
                {
                    throw new Exception("Ha ocurrido un error interno y no se pudo obtener la configuracion.");
                }
            }
            return _topeMaximoPagina;
        }

        // GET: ArticuloController
        public ActionResult Index(string mensaje, string fechaDesde, string fechaHasta, int numPag = 1)
        {
            try
            {
                //obtener token
                string token = HttpContext.Session.GetString("token");
                if (String.IsNullOrEmpty(token))
                {
                    return RedirectToAction("Login", "Home", new { mensaje = "Por favor, ingrese sus datos para iniciar sesion" });
                }
                _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    token
                );
                ViewBag.mensaje = mensaje;
                paginaActual = numPag;
                ViewBag.Pagina = paginaActual;
                if(_topeMaximoPagina == 0) { ObtenerValorConfig(); }
                ViewBag.TopeMax = _topeMaximoPagina;
                if (!string.IsNullOrEmpty(fechaDesde) && !string.IsNullOrEmpty(fechaHasta))
                {
                    HttpRequestMessage solicitudArticulos = new HttpRequestMessage(HttpMethod.Get, new Uri($"{_urlBase}/Articulo/{fechaDesde}/{fechaHasta}?numPag={numPag}"));
                    Task<HttpResponseMessage> respuestaArticulos = _cliente.SendAsync(solicitudArticulos);
                    respuestaArticulos.Wait();

                    if (respuestaArticulos.Result.IsSuccessStatusCode)
                    {
                        string articulosComoTexto = respuestaArticulos.Result.Content.ReadAsStringAsync().Result;
                        var articulos = JsonConvert.DeserializeObject<IEnumerable<ArticuloModel>>(articulosComoTexto);
                        ViewBag.fechaDesde = fechaDesde;
                        ViewBag.fechaHasta = fechaHasta;
                        return View(articulos);
                    }
                    else
                    {
                        string articulosComoTexto = respuestaArticulos.Result.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Index", "Articulo", new { mensaje = articulosComoTexto });
                    }
                }
                return View(new List<ArticuloModel>());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home", new { mensaje = "Ha ocurrido un error al procesar la solicitud." });
            }
        }

        [HttpPost]
        public ActionResult Siguiente(string fechaDesde, string fechaHasta)
        {
            paginaActual++;
            return RedirectToAction("Index", new { numPag = paginaActual, fechaDesde = fechaDesde, fechaHasta = fechaHasta });
        }

        [HttpPost]
        public ActionResult Anterior(string fechaDesde, string fechaHasta)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
            }
            else
            {
                paginaActual = 1;
            }
            return RedirectToAction("Index", new { numPag = paginaActual, fechaDesde = fechaDesde, fechaHasta = fechaHasta });
        }

    }
}
