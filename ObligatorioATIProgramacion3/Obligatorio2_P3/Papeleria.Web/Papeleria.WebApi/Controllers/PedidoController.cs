using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.Exceptions;
using System.Collections.Generic;

namespace Papeleria.WebApi.Controllers
{
    [Route("api/Pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IObtenerPedidos _obtenerPedidosCU;
        public PedidoController(IObtenerPedidos obtenerPedidosCU)
        {
            _obtenerPedidosCU = obtenerPedidosCU;
        }

        /// <summary>
        /// Método que permite obtener los pedidos que han sido anulados.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado para consultar todos los pedidos anulados existentes en la base de datos. No requiere autenticacion para acceder a esta información.
        /// </remarks>
        /// <returns> Listado de pedidos anulados </returns>
        /// <response code="200">Devuelve la lista de pedidos anulados.</response>
        /// <response code="204">Devuelve un resultado exitoso pero avisa que la lista no tiene contenido.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        [HttpGet("Anulados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<PedidoDto>> ObtenerPedidosAnulados()
        {
            try
            {
                IEnumerable <PedidoDto> pedidosAnulados = _obtenerPedidosCU.ObtenerPedidosAnulados();
                if(pedidosAnulados != null && pedidosAnulados.Any())
                {
                    return Ok(pedidosAnulados);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "No se pudieron mostrar los pedidos anulados");
            }
        }

    }
}
