using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Configuraciones;
using Papeleria.LogicaNegocio.Exceptions;

namespace Papeleria.WebApi.Controllers
{
    [Route("api/Configuracion")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private IObtenerValorConfigPorNombre _obtenerValorConfigCU;

        public ConfiguracionController(IObtenerValorConfigPorNombre obtenerValorConfigCU)
        {
            _obtenerValorConfigCU = obtenerValorConfigCU;
        }

        /// <summary>
        /// Método que permite obtener una configuracion a traves de su nombre.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado para consultar una configuracion a traves de su nombre. Es importante que el usuario esté autenticado 
        /// y tenga los permisos necesarios para acceder a esta información.
        /// </remarks>
        /// <returns> Valor de configuracion </returns>
        /// <response code="200">Devuelve el valor de configuracion exitosamente.</response>
        /// <response code="400">Devuelve un error si el parametro nombre no cumple con lo establecido.</response>
        /// <response code="401">Usuario no autorizado.</response>
        /// <response code="403">El usuario no tiene los permisos necesarios para acceder a este recurso.</response>
        /// <response code="404">No existe una configuracion con ese nombre, no fue encontrado.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        // GET api/<ConfiguracionController>/Nombre
        [HttpGet("Nombre/{nombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public ActionResult<double> ObtenerValorPorNombre(string nombre)
        {
            try
            {
                if (String.IsNullOrEmpty(nombre))
                {
                    return BadRequest("Debe ingresar el nombre de configuracion");
                }
                double toReturn = this._obtenerValorConfigCU.ObtenerValorPorNombre(nombre);
                if (toReturn > 0)
                {
                    return Ok(toReturn);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, $"No se encontro la configuracion para {nombre} en nuestra base de datos");
            }
        }
    }
}
