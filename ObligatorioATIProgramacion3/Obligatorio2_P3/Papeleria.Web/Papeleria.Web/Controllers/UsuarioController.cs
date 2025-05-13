using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Administrador;
using Papeleria.LogicaAplicacion.InterfacesCU.Encriptacion;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.ValueObjects;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Papeleria.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IAgregarUsuario _agregarUsuarioCU;
        private IEliminarUsuario _eliminarUsuarioCU;
        private IModificarUsuario _modificarUsuarioCU;
        private IObtenerUsuarioPorId _obtenerUsuarioPorIdCU;
        private IObtenerUsuarios _obtenerUsuariosCU;

        public UsuarioController(
            IAgregarUsuario agregarUsuarioCU,
            IEliminarUsuario eliminarUsuarioCU,
            IModificarUsuario modificarUsuarioCU,
            IObtenerUsuarioPorId obtenerUsuarioPorIdCU,
            IObtenerUsuarios obtenerUsuariosCU)
        {
            _agregarUsuarioCU = agregarUsuarioCU;
            _eliminarUsuarioCU = eliminarUsuarioCU;
            _modificarUsuarioCU = modificarUsuarioCU;
            _obtenerUsuarioPorIdCU = obtenerUsuarioPorIdCU;
            _obtenerUsuariosCU = obtenerUsuariosCU;
        }

        // GET: UsuarioController
        public ActionResult Index(string mensaje)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                ViewBag.Mensaje = mensaje;
                return View(_obtenerUsuariosCU.ObtenerUsuarios());
            }
            return RedirectToAction("Logout", "Home");
        }


        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    return View(_obtenerUsuarioPorIdCU.ObtenerUsuario(id));
                }
                catch (UsuarioInvalidoException e)
                {
                    ViewBag.msgError = e.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.msgError = ex.Message;
                    return View();
                }
            }
            return RedirectToAction("Logout", "Home");
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                return View();
            }
            return RedirectToAction("Logout", "Home");
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDto aAgregar)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    _agregarUsuarioCU.AgregarAdmin(aAgregar);
                    return RedirectToAction(nameof(Index), new { mensaje = $"Usuario {aAgregar.Nombre} agregado con éxito" });
                }
                catch (UsuarioInvalidoException e)
                {
                    ViewBag.msgErrorEmail = e.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.msgError = ex.Message;
                    return View();
                }
            }
            return RedirectToAction("Logout", "Home");
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                return View(_obtenerUsuarioPorIdCU.ObtenerUsuario(id));
            }
            return RedirectToAction("Logout", "Home");
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioDto aModificar)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    _modificarUsuarioCU.ModificarAdmin(aModificar);
                    return RedirectToAction(nameof(Index));
                }
                catch (UsuarioInvalidoException e)
                {
                    ViewBag.msgError = e.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.msgError = ex.Message;
                    return View();
                }
            }
            return RedirectToAction("Logout", "Home");
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                return View(_obtenerUsuarioPorIdCU.ObtenerUsuario(id));
            }
            return RedirectToAction("Logout", "Home");
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    _eliminarUsuarioCU.EliminarUsuario(id);
                    if (id == HttpContext.Session.GetInt32("idUsuarioLogueado"))
                    {
                        TempData["UsuarioEliminado"] = "Un administrador lo ha eliminado del sistema";
                        return RedirectToAction("Logout", "Home");
                    }
                    return RedirectToAction(nameof(Index), new { mensaje = "Usuario Eliminado." });
                }
                catch (UsuarioInvalidoException e)
                {
                    ViewBag.msgError = e.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.msgError = "No Fue posible eliminar el usuario.";
                    return View();
                }
            }
            return RedirectToAction("Logout", "Home");
        }
    }
}
