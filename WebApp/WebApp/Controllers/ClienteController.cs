using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {
        Sistema s = Sistema.GetInstancia();


        public IActionResult Index()
        {
            List<Cliente> listaClientes = s.GetClientes();
            ViewBag.Clientes = listaClientes;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente c)
        {
            try
            {
                s.AltaCliente(c);
                return RedirectToAction("Index"); // redirige a otro controlador, sirve para redirigir directamente.
                //ViewBag.mensaje = "usuario creado correctamente";
            }
            catch (Exception e)
            {
                ViewBag.mensaje = "Error";
            }

            return View();
        }




    }
}
