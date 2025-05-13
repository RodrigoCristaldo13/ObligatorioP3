using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.Web.Controllers
{
    public class ArticuloController : Controller
    {
        private IAgregarArticulo _agregarArticuloCU;
        private IModificarArticulo _modificarArticuloCU;
        private IObtenerArticuloPorId _obtenerArticuloPorIdCU;
        private IObtenerArticulos _obtenerArticulosCU;

        public ArticuloController(
            IAgregarArticulo agregarArticuloCU,
            IModificarArticulo modificarArticuloCU,
            IObtenerArticuloPorId obtenerArticuloPorIdCU,
            IObtenerArticulos obtenerArticulosCU)
        {
            _agregarArticuloCU = agregarArticuloCU;
            _modificarArticuloCU = modificarArticuloCU;
            _obtenerArticuloPorIdCU = obtenerArticuloPorIdCU;
            _obtenerArticulosCU = obtenerArticulosCU;
        }

        // GET: ArticuloController
        public ActionResult Index(string mensaje)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                ViewBag.mensaje = mensaje;
                return View(_obtenerArticulosCU.ObtenerArticulos());
            }
            return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });

        }

        //// GET: ArticuloController/Details/5
        //public ActionResult Details(int id)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        return View(_obtenerArticuloPorIdCU.ObtenerArticulo(id));
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloDto aAgregar)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    _agregarArticuloCU.AgregarArticulo(aAgregar);
                    return RedirectToAction(nameof(Index), new { mensaje = $"Articulo {aAgregar.Nombre} creado correctamente" });
                }
                catch (ArticuloInvalidoException e)
                {
                    ViewBag.msgValidacion = e.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.msgError = "Error al agregar el usuario";
                    return View();
                }
            }
            return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        }

        //// GET: ArticuloController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        return View(_obtenerArticuloPorIdCU.ObtenerArticulo(id));
        //    }
        //    return RedirectToAction("Index", "Home");

        //}

        //// POST: ArticuloController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Articulo aModificar)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        try
        //        {
        //            _modificarArticuloCU.ModificarArticulo(aModificar);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //    return RedirectToAction("Index", "Home");

        //}

        //  EVALUAR SI ES NECESARIO ELIMINAR ARTICULOS

        //// GET: ArticuloController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        return View(_obtenerArticuloPorIdCU.ObtenerArticulo(id));
        //    }
        //    return RedirectToAction("Index", "Home");

        //}

        //// POST: ArticuloController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
