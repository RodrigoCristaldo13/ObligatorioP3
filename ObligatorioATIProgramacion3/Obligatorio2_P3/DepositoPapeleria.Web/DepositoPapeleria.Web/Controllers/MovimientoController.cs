using DepositoPapeleria.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DepositoPapeleria.Web.Controllers
{
    public class MovimientoController : Controller
    {
        private HttpClient _cliente;
        private string _urlBase;
        private static int paginaActual;
        private static int _topeMaximoPagina;
        private static IEnumerable<ArticuloModel> _articulosTemp;
        private static IEnumerable<TipoMovimientoModel> _tiposMovimientoTemp;
        private static IEnumerable<ResumenModel> _resumenTemp;

        public MovimientoController()
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

                if (respuestaConfig.Result.IsSuccessStatusCode)
                {
                    //parseamos el valor de config
                    string valorComoTexto = respuestaConfig.Result.Content.ReadAsStringAsync().Result;
                    int valor = Int32.Parse(valorComoTexto);
                    _topeMaximoPagina = valor;
                }
                else
                {
                    throw new Exception("Ha ocurrido un error interno y no se obtener la configuracion.");
                }
            }
            return _topeMaximoPagina;
        }

        public IEnumerable<ArticuloModel> ObtenerArticulos()
        {
            if (_articulosTemp == null)
            {
                // solicitud para obtener articulos
                HttpRequestMessage solicitudArticulos = new HttpRequestMessage(HttpMethod.Get, new Uri($"{_urlBase}/Articulo"));
                Task<HttpResponseMessage> respuestaArticulos = _cliente.SendAsync(solicitudArticulos);
                respuestaArticulos.Wait();

                if (respuestaArticulos.Result.IsSuccessStatusCode)
                {
                    //parseamos los articulos obtenidos
                    string articulosComoTexto = respuestaArticulos.Result.Content.ReadAsStringAsync().Result;
                    var articulos = JsonConvert.DeserializeObject<IEnumerable<ArticuloModel>>(articulosComoTexto);
                    _articulosTemp = articulos;
                }
                else
                {
                    throw new Exception("Ha ocurrido un error interno y no se pudieron cargar correctamente los Articulos.");
                }
            }
            return _articulosTemp;
        }

        public IEnumerable<TipoMovimientoModel> ObtenerTiposMovimiento()
        {
            if (_tiposMovimientoTemp == null)
            {
                // solicitud para obtener tipos de movimiento
                HttpRequestMessage solicitudTiposMov = new HttpRequestMessage(HttpMethod.Get, new Uri($"{_urlBase}/TipoMovimiento"));
                Task<HttpResponseMessage> respuestaTiposMov = _cliente.SendAsync(solicitudTiposMov);
                respuestaTiposMov.Wait();

                if (respuestaTiposMov.Result.IsSuccessStatusCode)
                {
                    //parsemos los tipos de movimientos obtenidos
                    string tiposMovComoTexto = respuestaTiposMov.Result.Content.ReadAsStringAsync().Result;
                    var tiposMov = JsonConvert.DeserializeObject<IEnumerable<TipoMovimientoModel>>(tiposMovComoTexto);
                    _tiposMovimientoTemp = tiposMov;
                }
                else
                {
                    throw new Exception("Ha ocurrido un error interno y no se pudieron cargar correctamente los Tipos de Movimiento.");
                }
            }
            return _tiposMovimientoTemp;
        }

        // GET: MovimientoController
        public ActionResult Index(string mensaje, string mensajeOk, int numPag = 1, string tipo = null, int idArticulo = 0)
        {
            try
            {
                //obtenemos el token
                string token = HttpContext.Session.GetString("token");
                if (String.IsNullOrEmpty(token))
                {
                    return RedirectToAction("Login", "Home", new { mensaje = "Por favor, ingrese sus datos para iniciar sesion" });
                }
                //configuramos autorizacion del cliente HTTP
                _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    token
                );
                //mensajes de la vista
                ViewBag.mensaje = mensaje;
                ViewBag.mensajeOk = mensajeOk;
                paginaActual = numPag;
                ViewBag.Pagina = paginaActual;

                // obtener articulos
                if (_articulosTemp == null) { ObtenerArticulos(); }
                ViewBag.Articulos = _articulosTemp;
                //obtener tipo
                if (_tiposMovimientoTemp == null) { ObtenerTiposMovimiento(); }
                ViewBag.TiposMovimiento = _tiposMovimientoTemp;
                //obtener valor de config
                if (_topeMaximoPagina == 0) { ObtenerValorConfig(); }
                ViewBag.TopeMax = _topeMaximoPagina;

                if (!string.IsNullOrEmpty(tipo) && idArticulo > 0)
                {
                    // obtener movs de articulo y tipo
                    HttpRequestMessage solicitudMovimientos = new HttpRequestMessage(HttpMethod.Get, new Uri($"{_urlBase}/Movimiento/Tipo/{tipo}/Articulo/{idArticulo}?numPag={paginaActual}"));
                    Task<HttpResponseMessage> respuestaMovimientos = _cliente.SendAsync(solicitudMovimientos);
                    respuestaMovimientos.Wait();

                    if (respuestaMovimientos.Result.IsSuccessStatusCode)
                    {
                        string movimientosComoTexto = respuestaMovimientos.Result.Content.ReadAsStringAsync().Result;
                        var movimientos = JsonConvert.DeserializeObject<IEnumerable<MovimientoModel>>(movimientosComoTexto);
                        ViewBag.Articulo = _articulosTemp.Where(a => a.Id.Equals(idArticulo)).First();
                        ViewBag.TipoMov = _tiposMovimientoTemp.Where(t => t.Nombre == tipo).First();
                        return View(movimientos);
                    }
                    else
                    {
                        string movimientosComoTexto = respuestaMovimientos.Result.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Index", "Movimiento", new { mensaje = $"{movimientosComoTexto}" });
                    }
                }
                return View(new List<MovimientoModel>());
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Movimiento", new { mensaje = "Ha ocurrido un error al procesar la solicitud." });
            }
        }
        //Action para avanzar de pagina
        [HttpPost]
        public ActionResult Siguiente(string tipo, int idArticulo)
        {
            paginaActual++;
            return RedirectToAction("Index", new { numPag = paginaActual, tipo = tipo, idArticulo = idArticulo });
        }
        //Action para retroceder de pagina
        [HttpPost]
        public ActionResult Anterior(string tipo, int idArticulo)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
            }
            else
            {
                paginaActual = 1;
            }
            return RedirectToAction("Index", new { numPag = paginaActual, tipo = tipo, idArticulo = idArticulo });
        }

        // GET: MovimientoController/Resumen
        public ActionResult Resumen()
        {
            try
            {
                //obtener el token
                string token = HttpContext.Session.GetString("token");
                if (String.IsNullOrEmpty(token))
                {
                    return RedirectToAction("Login", "Home", new { mensaje = "Por favor, ingrese sus datos para iniciar sesion" });
                }
                //config autorizacion del cliente
                _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    token
                );
                // obtener movs de articulo y tipo
                HttpRequestMessage solicitudResumen = new HttpRequestMessage(HttpMethod.Get, new Uri($"{_urlBase}/Movimiento/Resumen"));
                Task<HttpResponseMessage> respuestaResumen = _cliente.SendAsync(solicitudResumen);
                respuestaResumen.Wait();

                if (respuestaResumen.Result.IsSuccessStatusCode)
                {
                    string resumenComoTexto = respuestaResumen.Result.Content.ReadAsStringAsync().Result;
                    _resumenTemp = JsonConvert.DeserializeObject<IEnumerable<ResumenModel>>(resumenComoTexto);
                    return View(_resumenTemp);
                }
                else
                {
                    string resumenComoTexto = respuestaResumen.Result.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("Index", "Movimiento", new { mensaje = $"{resumenComoTexto}" });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Movimiento", new { mensaje = "Ha ocurrido un error al procesar la solicitud." });
            }
        }

        public ActionResult Details(int anio)
        {
            try
            {
                //obtener el token
                string token = HttpContext.Session.GetString("token");
                if (String.IsNullOrEmpty(token))
                {
                    return RedirectToAction("Login", "Home", new { mensaje = "Por favor, ingrese sus datos para iniciar sesion" });
                }
                if (_resumenTemp != null)
                {
                    //obtener resumen
                    ResumenModel resumen = _resumenTemp.Where(r => r.Anio.Equals(anio)).First();
                    return View(resumen);
                }
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Ha ocurrido un error al procesar la solicitud.";
                return View();
            }
        }

        // GET: MovimientoController/Create
        public ActionResult Create(string mensaje, string mensajeOk)
        {
            try
            {
                //obtener token de la sesion
                string token = HttpContext.Session.GetString("token");
                if (String.IsNullOrEmpty(token))
                {
                    return RedirectToAction("Login", "Home", new { mensaje = "Por favor, ingrese sus datos para iniciar sesion" });
                }
                //configurar mensajes de la vista
                ViewBag.mensaje = mensaje;
                ViewBag.mensajeOk = mensajeOk;

                // obtener articulos
                if (_articulosTemp == null) { ObtenerArticulos(); }
                ViewBag.Articulos = _articulosTemp;
                //obtener tipo
                if (_tiposMovimientoTemp == null) { ObtenerTiposMovimiento(); }
                ViewBag.TiposMovimiento = _tiposMovimientoTemp;

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { mensaje = "Error al obtener los datos, reintente" });
            }

        }

        // POST: MovimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovimientoModel movimiento)
        {
            try
            {
                //obtener token
                string token = HttpContext.Session.GetString("token");
                string emailLogueado = HttpContext.Session.GetString("emailLogueado");
                if (String.IsNullOrEmpty(token))
                {
                    return RedirectToAction("Login", "Home", new { mensaje = "Por favor, ingrese sus datos para iniciar sesion" });
                }
                //configurar autorizacion del cliente
                _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    token
                );
                if (movimiento.Cantidad < 1)
                {
                    return RedirectToAction("Create", new { mensaje = "Cantidad invalida, debe ser positiva." });
                }
                movimiento.EmailEncargado = emailLogueado; // agregamos el email de la session
                HttpRequestMessage solicitudCreate = new HttpRequestMessage(HttpMethod.Post, new Uri($"{_urlBase}/Movimiento"));
                string json = JsonConvert.SerializeObject(movimiento);
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
                solicitudCreate.Content = contenido;
                Task<HttpResponseMessage> respuestaCreate = _cliente.SendAsync(solicitudCreate);
                respuestaCreate.Wait();

                if (respuestaCreate.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Create", new { mensajeOk = "Se ha agregado un nuevo movimiento!." });
                }
                else
                {
                    string respuestaComoTexto = respuestaCreate.Result.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("Create", "Movimiento", new { mensaje = $"{respuestaComoTexto}" });
                }
            }
            catch
            {
                return RedirectToAction("Create", new { mensaje = "Error al crear, reintente" });
            }
        }
    }
}