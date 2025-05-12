using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;

namespace Papeleria.Web.Controllers
{
    public class ClienteController : Controller
    {
        private IObtenerClientes _obtenerClientesCU;
        private IObtenerClientePorId _obtenerClientePorIdCU;
        private IObtenerClientesPorTexto _obtenerClientesPorTextoCU;
        private IObtenerClientesMontoTotalMayorA _obtenerClientesMontoTotalMayorACU;

        public ClienteController(
            IObtenerClientes obtenerClientesCU,
            IObtenerClientesPorTexto obtenerClientesPorTextoCU,
            IObtenerClientePorId obtenerClientePorIdCU,
            IObtenerClientesMontoTotalMayorA obtenerClientesMontoTotalMayorACU)
        {
            _obtenerClientesCU = obtenerClientesCU;
            _obtenerClientesPorTextoCU = obtenerClientesPorTextoCU;
            _obtenerClientePorIdCU = obtenerClientePorIdCU;
            _obtenerClientesMontoTotalMayorACU = obtenerClientesMontoTotalMayorACU;
        }

        //GET: ClienteController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                return View(_obtenerClientesCU.ObtenerClientes());
            }
            return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        }


        [HttpPost]
        public ActionResult Index(string texto, double montoTotal)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    ViewBag.Filtro = $"Se filtraron los Clientes que contienen '{texto}' en el Nombre o Apellido de su Contacto";
                    return View(_obtenerClientesPorTextoCU.ObtenerClientes(texto));
                }
                else if (montoTotal > 0)
                {
                    ViewBag.Filtro = $"Se filtraron los Clientes con pedidos con monto total mayor a ${montoTotal}";
                    return View(_obtenerClientesMontoTotalMayorACU.ObtenerClientes(montoTotal));
                }
                else
                {
                    return View(_obtenerClientesCU.ObtenerClientes());
                }
            }
            return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        }


        //// GET: ClienteController/Details/5
        //public ActionResult Details(int id)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        return View(_obtenerClientePorIdCU.ObtenerCliente(id));
        //    }
        //    return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        //}

        //// GET: ClienteController/Create
        //public ActionResult Create()
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        return View();
        //    }
        //    return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        //}

        //// POST: ClienteController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
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
        //    return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        //}

        //// GET: ClienteController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        return View(_obtenerClientePorIdCU.ObtenerCliente(id));
        //    }
        //    return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        //}

        //// POST: ClienteController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
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
        //    return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        //}

        //// GET: ClienteController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        return View();
        //    }
        //    return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        //}

        //// POST: ClienteController/Delete/5
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
        //    return RedirectToAction("Index", "Home", new { mensaje = "Para continuar debe iniciar sesión" });
        //}
    }
}
