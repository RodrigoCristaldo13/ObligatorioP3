using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Movimientos;
using Papeleria.LogicaNegocio.Exceptions;

namespace Papeleria.WebApi.Controllers
{
    [ApiController]
    [Route("api/Articulo")]
    public class ArticuloController : ControllerBase
    {
        private IObtenerArticulos _obtenerArticulosCU;
        private IObtenerArticulosConMovimientosEntreFechas _obtenerArticulosConMovimientosEntreFechasCU;

        public ArticuloController(
            IObtenerArticulos obtenerArticulosCU,
            IObtenerArticulosConMovimientosEntreFechas obtenerArticulosConMovimientosEntreFechas)
        {
            _obtenerArticulosCU = obtenerArticulosCU;
            _obtenerArticulosConMovimientosEntreFechasCU = obtenerArticulosConMovimientosEntreFechas;
        }

        /// <summary>
        /// Método que permite obtener los articulos existentes ordenados ascendentemente por Nombre.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado para obtener los articulos existentes ordenados ascendentemente por Nombre. No es necesario estar autenticado para acceder a esta información.
        /// </remarks>
        /// <returns> Lista de movimientos existentes </returns>
        /// <response code="200">Devuelve la lista de articulos existentes.</response>
        /// <response code="204">Devuelve un resultado exitoso pero avisa que la lista no tiene contenido.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ArticuloDto>> ObtenerArticulos()
        {
            try
            {
                IEnumerable<ArticuloDto> losArticulos = _obtenerArticulosCU.ObtenerArticulos();
                if (losArticulos != null && losArticulos.Count() > 0)
                {
                    return Ok(losArticulos);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "No se pudieron mostrar los articulos");
            }
        }


        /// <summary>
        /// Método que permite al usuario autenticado como Encargado del depósito obtener los articulos que participan en movimientos dentro de un rango de fechas.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado por los encargados del depósito para consultar todos los articulos registrados
        /// en el sistema que participan en movimientos entre una fecha inicial y una fecha final. 
        /// Es importante que el usuario esté autenticado y tenga los permisos necesarios para acceder a esta información.
        /// </remarks>
        /// <param name="fechaDesde">Fecha inicial de busqueda. (Ej. 23-04-2024)</param>
        /// <param name="fechaHasta">Fecha final de busqueda. (Ej. 10-06-2024)</param>
        /// <param name="numPag">Numero de pagina que el usuario desea visualizar (Ej. 3)</param>
        /// <returns>
        /// Lista de articulos existentes que esten incluidos en Movimientos que fueron realizados entre estas fechas
        /// </returns>
        /// <response code="200">Devuelve la lista de articulos existentes que cumplan con lo mencionado.</response>
        /// <response code="204">Devuelve un resultado exitoso pero avisa que la lista no tiene contenido.</response>
        /// <response code="400">Alguno de los parametros no cumple con lo establecido.</response>
        /// <response code="401">No autorizado. El usuario no está autenticado o no tiene permisos suficientes.</response>
        /// <response code="403">El usuario no tiene los permisos necesarios para acceder a este recurso.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        [HttpGet("{fechaDesde}/{fechaHasta}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public ActionResult<ArticuloDto> ObtenerArticulosPorMovimientoEntreFechas(string fechaDesde, string fechaHasta, int numPag)
        {
            try
            {
                if (numPag <= 0)
                {
                    numPag = 1;
                }
                if (String.IsNullOrEmpty(fechaDesde))
                {
                    return BadRequest("La fecha final debe ser valida.");
                }
                if (String.IsNullOrEmpty(fechaHasta))
                {
                    return BadRequest("La fecha final debe ser valida.");
                }
                IEnumerable<ArticuloDto> toReturn = _obtenerArticulosConMovimientosEntreFechasCU.ObtenerArticulosConMovimientosEntreFechas(fechaDesde, fechaHasta, numPag);
                return Ok(toReturn);
            }
            catch (ArticuloInvalidoException)
            {
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un problema al procesar la solicitud.");
            }
        }

    }
}
