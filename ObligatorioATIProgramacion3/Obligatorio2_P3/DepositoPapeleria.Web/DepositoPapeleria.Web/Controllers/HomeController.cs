using DepositoPapeleria.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace DepositoPapeleria.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _cliente;
        private string _urlBase;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _cliente = new HttpClient();
            _urlBase = "http://localhost:5141/api/Login";
        }

        public IActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            //verificar si hay usuario logueado, mostrar mensaje correspondiente
            if (HttpContext.Session.GetString("nombreCompletoLogueado") != null)
            {
                ViewBag.MensajeLogin = $"Sesión iniciada por Encargado(a) {HttpContext.Session.GetString("nombreCompletoLogueado")}";
            }
            else if (TempData["Logout"] != null)
            {
                ViewBag.msgLogout = TempData["Logout"] as string;
                return View();
            }
            return View();
        }

        public IActionResult Login(string mensaje)
        {
            ViewBag.MensajeLogin = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string password)
        {
            try
            {
                //solicitud de login
                HttpRequestMessage solicitudLogin = new HttpRequestMessage(HttpMethod.Post, new Uri(_urlBase));
                TokenLoginModel anonimo = new TokenLoginModel
                {
                    Email = correo,
                    Password = password
                };
                //conviertir modelo a JSON
                string json = JsonConvert.SerializeObject(anonimo);
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
                solicitudLogin.Content = contenido;
                //enviar solicitud de login y esperamos respuesta
                Task<HttpResponseMessage> respuestaLogin = _cliente.SendAsync(solicitudLogin);
                respuestaLogin.Wait();
                //guardamos datos si respuesta es OK
                if (respuestaLogin.Result.IsSuccessStatusCode)
                {
                    var respuestaComoTexto = respuestaLogin.Result.Content.ReadAsStringAsync().Result;
                    var tokenLogin = JsonConvert.DeserializeObject<TokenLoginModel>(respuestaComoTexto);
                    HttpContext.Session.SetString("emailLogueado", correo);
                    HttpContext.Session.SetString("token", tokenLogin.Token);
                    HttpContext.Session.SetString("nombreCompletoLogueado", $"{tokenLogin.Nombre} {tokenLogin.Apellido}");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var respuestaComoTexto = respuestaLogin.Result.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("Login", new { mensaje = $"{respuestaComoTexto}" });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", new { mensaje = "Ocurrio un error al procesar la solicitud, por favor intente nuevamente." });
            }
        }

        public IActionResult Logout()
        {
            //verificar usuario logueado
            if (HttpContext.Session.GetInt32("emailLogueado") != null)
            {
                //limpiar sesion y redirigir a index
                HttpContext.Session.Clear();
                TempData["Logout"] = "La sesión ha sido cerrada.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Logout"] = "Por favor, Inicie sesión para continuar. ";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Privacy()
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
