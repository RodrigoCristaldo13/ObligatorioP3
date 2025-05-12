using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Administradores;
using Papeleria.LogicaAplicacion.InterfacesCU.Encriptacion;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.Web.Models;
using System.Diagnostics;

namespace Papeleria.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILoginUsuario _loginUsuarioCU;
        public HomeController(ILoginUsuario loginUsuarioCU)
        {
            _loginUsuarioCU = loginUsuarioCU;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("NombreUsuario") != null)
            {
                ViewBag.msgLogin = $"Sesión iniciada, Admin {HttpContext.Session.GetString("NombreUsuario")}";
            }
            else if (TempData["Logout"] != null)
            {
                ViewBag.msgLogout = TempData["Logout"] as string;
                if(TempData["UsuarioEliminado"] != null)
                {
                    ViewBag.msgLogout += TempData["UsuarioEliminado"] as string;
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") == null)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login(string correo, string password)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") == null)
            {
                try
                {
                    UsuarioDto usuarioLogin = _loginUsuarioCU.Login(correo, password);
                    if (usuarioLogin != null && usuarioLogin.Rol == "Administrador")
                    {
                        HttpContext.Session.SetInt32("idUsuarioLogueado", usuarioLogin.Id);
                        HttpContext.Session.SetString("NombreUsuario", $"{usuarioLogin.Nombre} {usuarioLogin.Apellido}");
                        return RedirectToAction("Index");
                    }
                    ViewBag.msgError = "Solo los Administradores tienen acceso.";
                    return View();
                }
                catch (UsuarioInvalidoException e)
                {
                    ViewBag.msgLogin = e.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.msgError = "No se pudieron recuperar los datos, se perdió la conexión con la Base de Datos.";
                    return View();
                }
            }
            return RedirectToAction("Logout");
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                HttpContext.Session.Clear();
                TempData["Logout"] = "La sesión ha sido cerrada. ";
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
