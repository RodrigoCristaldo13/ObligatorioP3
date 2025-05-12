using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using Papeleria.LogicaAplicacion.CasosDeUso.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.Web.Models;
using System.Globalization;

namespace Papeleria.Web.Controllers
{
    public class PedidoController : Controller
    {
        private IAgregarPedido _agregarPedidoCU;
        private IAnularPedido _anularPedidoCU;
        private IObtenerPedidoPorId _obtenerPedidoPorIdCU;
        private IObtenerPedidos _obtenerPedidosCU;

        private IObtenerClientes _obtenerClientesCU;
        private IObtenerClientePorId _obtenerClientePorIdCU;

        private IObtenerArticulos _obtenerArticulosCU;
        private IObtenerArticuloPorId _obtenerArticuloPorIdCU;

        private static PedidoDto tempPedido;

        public PedidoController(
            IAgregarPedido agregarPedidoCU,
            IAnularPedido anularPedidoCU,
            IObtenerPedidoPorId obtenerPedidoPorIdCU,
            IObtenerPedidos obtenerPedidosCU,
            IObtenerClientes obtenerClientesCU,
            IObtenerArticulos obtenerArticulosCU,
            IObtenerArticuloPorId obtenerArticuloPorIdCU,
            IObtenerClientePorId obtenerClientePorIdCU)
        {
            _agregarPedidoCU = agregarPedidoCU;
            _anularPedidoCU = anularPedidoCU;
            _obtenerPedidoPorIdCU = obtenerPedidoPorIdCU;
            _obtenerPedidosCU = obtenerPedidosCU;
            _obtenerClientesCU = obtenerClientesCU;
            _obtenerArticulosCU = obtenerArticulosCU;
            _obtenerArticuloPorIdCU = obtenerArticuloPorIdCU;
            _obtenerClientePorIdCU = obtenerClientePorIdCU;
        }

        // GET: PedidoController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    tempPedido = null;
                    if (TempData["Mensaje"] != null)
                    {
                        ViewBag.mensaje = TempData["Mensaje"] as string;
                    }
                    DateTime fake = DateTime.MinValue;
                    List<PedidoDto> pedidosDto = _obtenerPedidosCU.ObtenerPedidosPendientes(fake).ToList();
                    return View(pedidosDto);
                }
                catch (PedidoInvalidoException)
                {
                    ViewBag.mensajeOk = "No hay pedidos pendientes de entrega.";
                    return View();
                }
                catch (Exception)
                {
                    ViewBag.mensajeError = "No se pudieron obtener los pedidos, se perdió la conexión con la Base de datos";
                    return View();
                }
            }
            return RedirectToAction("Logout", "Home");
        }

        // POST: PedidoController/Index/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string fecha)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    DateTime fechaForm;
                    DateTime.TryParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaForm);
                    List<PedidoDto> pedidosDto = _obtenerPedidosCU.ObtenerPedidosPendientes(fechaForm).ToList();
                    ViewBag.mensajeOk = $"Se muestran resultados del día {fechaForm.ToLongDateString()}";
                    return View(pedidosDto);
                }
                catch (PedidoInvalidoException e)
                {
                    ViewBag.mensajeOk = e.Message;
                    return View();
                }
                catch (Exception)
                {
                    ViewBag.mensajeError = "No se pudieron obtener los pedidos";
                    return View();
                }
            }
            return RedirectToAction("Logout", "Home");
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    PedidoDto elPedido = _obtenerPedidoPorIdCU.ObtenerPedido(id);
                    if (elPedido.LineasPedido != null && elPedido.LineasPedido.Count() > 0)
                    {
                        return View(elPedido);
                    }
                    else
                    {
                        ViewBag.Error = "No se pudieron cargar las lineas del pedido";
                        return View();
                    }
                }
                catch (PedidoInvalidoException ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
                catch (Exception)
                {
                    ViewBag.Error = "No se pudieron cargar los detalles del pedido";
                    return View();
                }
            }
            return RedirectToAction("Logout", "Home");
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                if (TempData["mensajeCantidad"] != null)
                {
                    ViewBag.Cantidad = TempData["mensajeCantidad"] as string;
                }
                if (TempData["mensajeCarrito"] != null)
                {
                    ViewBag.MensajeCarrito = TempData["mensajeCarrito"] as string;
                }
                List<ArticuloDto> articulosObtenidos = _obtenerArticulosCU.ObtenerArticulos().ToList();
                if (tempPedido != null && tempPedido.LineasPedido != null && tempPedido.LineasPedido.Count() > 0)
                {
                    ViewBag.LineasPedido = tempPedido.LineasPedido;
                    // Obtenemos los IDs de los artículos que tenemos en el carrito
                    List<int> idsArticulosEnCarrito = tempPedido.LineasPedido.Select(lp => lp.Articulo.Id).ToList();
                    // Queremos mostrar los artículos que no esten en el carrito
                    articulosObtenidos = articulosObtenidos.Where(a => !idsArticulosEnCarrito.Contains(a.Id)).ToList();
                }
                ViewBag.Clientes = _obtenerClientesCU.ObtenerClientes();
                ViewBag.Articulos = articulosObtenidos;
                return View();
            }
            tempPedido = null; // En caso de que la session se cierre por inactividad vaciamos el pedido temporal
            return RedirectToAction("Logout", "Home");
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDto aAgregar)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    ClienteDto cliente = _obtenerClientePorIdCU.ObtenerCliente(aAgregar.IdCliente);
                    aAgregar.Cliente = cliente;
                    if (tempPedido != null && tempPedido.LineasPedido.Count > 0)
                    {
                        aAgregar.LineasPedido = tempPedido.LineasPedido;
                    }
                    _agregarPedidoCU.AgregarPedido(aAgregar);
                    tempPedido = null;
                    TempData["Mensaje"] = $"Pedido agregado";
                    return RedirectToAction(nameof(Index));
                }
                catch (ClienteInvalidoException ex)
                {
                    ViewBag.msgError = ex.Message;
                    return View();
                }
                catch (PedidoInvalidoException e)
                {
                    ViewBag.msgError = e.Message;
                    ViewBag.LineasPedido = aAgregar.LineasPedido;
                    ViewBag.Clientes = _obtenerClientesCU.ObtenerClientes();
                    ViewBag.Articulos = _obtenerArticulosCU.ObtenerArticulos();
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.msgError = "Error al agregar el pedido";
                    ViewBag.Clientes = _obtenerClientesCU.ObtenerClientes();
                    ViewBag.Articulos = _obtenerArticulosCU.ObtenerArticulos();
                    return View();
                }
            }
            tempPedido = null; // En caso de que la session se cierre por inactividad vaciamos el pedido temporal
            return RedirectToAction("Logout", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLineaPedido(int idArticulo, int cantidad)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    if (cantidad < 1)
                    {
                        TempData["mensajeCantidad"] = "Debe ingresar una cantidad valida.";
                        return RedirectToAction(nameof(Create));
                    }
                    ArticuloDto articulo = _obtenerArticuloPorIdCU.ObtenerArticulo(idArticulo);
                    if (cantidad <= articulo.Stock) //Validamos que tengamos stock suficiente para el articulo ingresado
                    {
                        LineaPedidoDto lineaPedido = new LineaPedidoDto
                        {
                            IdArticulo = articulo.Id,
                            Articulo = articulo,
                            CantidadUnidadesPedidas = cantidad, 
                            PrecioUnitarioVigente = articulo.Precio,
                        };
                        if (tempPedido == null)
                        {
                            tempPedido = new PedidoDto { LineasPedido = new List<LineaPedidoDto>() };
                        }
                        tempPedido.LineasPedido.Add(lineaPedido);
                    }
                    else
                    {
                        TempData["mensajeCantidad"] = "No tenemos suficiente stock de este articulo.";
                        return RedirectToAction(nameof(Create));
                    }
                    TempData["mensajeCarrito"] = $"Ha agregado un nuevo articulo al carrito.";
                    return RedirectToAction(nameof(Create));
                }
                catch (Exception)
                {
                    TempData["mensajeCarrito"] = $"No se ha podido agregar el articulo al carrito.";
                    RedirectToAction(nameof(Create));
                }
            }
            tempPedido = null; // En caso de que la session se cierre por inactividad vaciamos el pedido temporal
            return RedirectToAction("Logout", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarLineaPedido(int idArticulo, double cantidad)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    if (tempPedido != null && tempPedido.LineasPedido.Any())
                    {
                        LineaPedidoDto lineaPedido = tempPedido.LineasPedido.Where(linea => linea.IdArticulo == idArticulo && linea.CantidadUnidadesPedidas == cantidad).FirstOrDefault();
                        tempPedido.LineasPedido.Remove(lineaPedido);
                    }
                    TempData["mensajeCarrito"] = "Ha eliminado el articulo del carrito.";
                    return RedirectToAction(nameof(Create));
                }
                catch(Exception)
                {
                    TempData["mensajeCarrito"] = "No se ha podido eliminar el articulo del carrito.";
                    return RedirectToAction(nameof(Create));
                }
            }
            tempPedido = null; // En caso de que la session se cierre por inactividad vaciamos el pedido temporal
            return RedirectToAction("Logout", "Home");
        }


        // Utillizamos Delete para la Anulacion del Pedido
        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {

            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    PedidoDto elPedido = _obtenerPedidoPorIdCU.ObtenerPedido(id);
                    if (elPedido.LineasPedido != null && elPedido.LineasPedido.Count() > 0)
                    {
                        return View(elPedido);
                    }
                    ViewBag.Error = "No se pudieron cargar las lineas del pedido";
                    return View();

                }
                catch (PedidoInvalidoException ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
                catch (Exception)
                {
                    ViewBag.Error = "No se pudieron cargar los detalles del pedido";
                    return View();
                }
            }
            return RedirectToAction("Logout", "Home");
        }

        //POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
            {
                try
                {
                    if (id != 0)
                    {
                        _anularPedidoCU.AnularPedido(id);
                        TempData["Mensaje"] = $"El pedido ha sido anulado exitosamente.";
                        return RedirectToAction(nameof(Index));
                    }
                    return View();
                }
                catch (PedidoInvalidoException ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
                catch (Exception)
                {
                    ViewBag.Error = "No se pudo anular el pedido";
                    return View();
                }
            }
            return RedirectToAction("Logout", "Home");
        }


        //// GET: PedidoController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        return View(_obtenerPedidoPorIdCU.ObtenerPedido(id));
        //    }
        //    return RedirectToAction("Index", "Home");

        //}

        //// POST: PedidoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, PedidoDto aAnular)
        //{
        //    if (HttpContext.Session.GetInt32("idUsuarioLogueado") != null)
        //    {
        //        try
        //        {
        //            _anularPedidoCU.AnularPedido(aAnular.Id);
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
