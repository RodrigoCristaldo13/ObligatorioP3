using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.CasosDeUso.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.TiposMovimientos;
using Papeleria.LogicaNegocio.Exceptions;


namespace Papeleria.WebApi.Controllers
{
    [Route("api/TipoMovimiento")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private IObtenerTiposMovimientos _obtenerTiposMovimientosCU;
        private IObtenerTipoMovimientoPorId _obtenerTipoMovimientoPorIdCU;
        private IAgregarTipoMovimiento _agregarTipoMovimientoCU;
        private IModificarTipoMovimiento _modificarTipoMovimientoCU;
        private IEliminarTipoMovimiento _eliminarTipoMovimientoCU;

        public TipoMovimientoController(
            IObtenerTiposMovimientos obtenerTiposMovimientosCU,
            IObtenerTipoMovimientoPorId obtenerTipoMovimientoPorIdCU,
            IAgregarTipoMovimiento agregarTipoMovimientoCU,
            IModificarTipoMovimiento modificarTipoMovimientoCU,
            IEliminarTipoMovimiento eliminarTipoMovimientoCU)
        {
            _obtenerTiposMovimientosCU = obtenerTiposMovimientosCU;
            _obtenerTipoMovimientoPorIdCU = obtenerTipoMovimientoPorIdCU;
            _agregarTipoMovimientoCU = agregarTipoMovimientoCU;
            _modificarTipoMovimientoCU = modificarTipoMovimientoCU;
            _eliminarTipoMovimientoCU = eliminarTipoMovimientoCU;
        }

        /// <summary>
        /// Método que permite obtener los tipos de movimiento existentes.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado para consultar todos los tipos de movimiento que hay
        /// en el sistema. No requiere autenticacion para acceder a esta información.
        /// </remarks>
        /// <returns> Lista de tipos de movimiento existentes </returns>
        /// <response code="200">Devuelve la lista de tipos de movimiento existentes.</response>
        /// <response code="204">Devuelve un resultado exitoso pero avisa que la lista no tiene contenido.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        // GET: api/<TipoMovimientoController>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<TipoMovimientoDto>> ObtenerTipos()
        {
            try
            {
                IEnumerable<TipoMovimientoDto> tipoMovimientos = _obtenerTiposMovimientosCU.ObtenerTipos();
                if (tipoMovimientos != null && tipoMovimientos.Count() > 0)
                {
                    return Ok(tipoMovimientos);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "No se pudieron mostrar los tipos de movimientos");
            }
        }

        /// <summary>
        /// Método que permite obtener un tipo de movimiento a traves de su ID.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado para consultar un tipo de movimiento a traves de su ID. No requiere autenticacion para acceder a esta información.
        /// </remarks>
        /// <returns> Tipo de movimiento con sus datos </returns>
        /// <response code="200">Devuelve el tipo de movimiento.</response>
        /// <response code="400">Devuelve un error si el parametro de tipoId no cumple con lo establecido.</response>
        /// <response code="404">No existe un tipo de movimiento con ese ID, no fue encontrado.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        // GET api/<TipoMovimientoController>/5
        [HttpGet("{tipoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipoMovimientoDto> ObtenerTipoPorId(int tipoId)
        {
            try
            {
                if (tipoId <= 0)
                {
                    return BadRequest("El Id debe ser un numero positivo");
                }
                TipoMovimientoDto toReturn = this._obtenerTipoMovimientoPorIdCU.ObtenerTipoPorId(tipoId);
                if (toReturn != null)
                {
                    return Ok(toReturn);
                }
                return NotFound();
            }
            catch (TipoMovimientoInvalidoException e)
            {
                return NotFound($"No se encontro un tipo de Movimiento con id {tipoId} en nuestra base de datos");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error.");
            }
        }

        /// <summary>
        /// Método que permite agregar un tipo de movimiento a la base de datos.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado para agregar un tipo de movimiento de la base de datos.
        /// No requiere autenticacion para agregar un nuevo tipo de movimiento.
        /// </remarks>
        /// <returns> Agrega un nuevo tipo de movimiento a la Base de datos </returns>
        /// <response code="201">Resultado exitoso, Tipo de Movimiento creado correctamente.</response>
        /// <response code="400">Algun dato del tipo de movimiento no cumple con el formato establecido.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        // POST api/<TipoMovimientoController>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipoMovimientoDto> AgregarTipo([FromBody] TipoMovimientoDto tipoMovimientoDto)
        {
            try
            {
                this._agregarTipoMovimientoCU.AgregarTipo(tipoMovimientoDto);
                return Created("api/TipoMovimiento", tipoMovimientoDto);
            }
            catch (TipoMovimientoInvalidoException)
            {
                return BadRequest("Tipo de Movimiento Invalido");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error.");
            }
        }

        /// <summary>
        /// Método que permite actualizar un tipo de movimiento existente en la base de datos.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado para actualizar un tipo de movimiento existente en la base de datos.
        /// No requiere autenticacion para actualizar el tipo de movimiento.
        /// </remarks>
        /// <returns> Actualiza un tipo de movimiento de la Base de datos </returns>
        /// <response code="200">Resultado exitoso, Tipo de Movimiento actualizado correctamente.</response>
        /// <response code="400">No se pudo actualizar el tipo por la razon detallada.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        // PUT api/<TipoMovimientoController>/5
        [HttpPut("{tipoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipoMovimientoDto> ModificarTipo([FromBody] TipoMovimientoDto tipoDto)
        {
            try
            {
                this._modificarTipoMovimientoCU.ModificarTipo(tipoDto);
                return Ok(tipoDto);
            }
            catch (TipoMovimientoInvalidoException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error.");
            }
        }

        /// <summary>
        /// Método que permite eliminar un tipo de movimiento de la base de datos.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado para eliminar un tipo de movimiento de la base de datos.
        /// No requiere autenticacion para agregar un nuevo tipo de movimiento.
        /// </remarks>
        /// <returns> Elimina un tipo de movimiento de la Base de datos </returns>
        /// <response code="200">Resultado exitoso, Tipo de Movimiento eliminado correctamente.</response>
        /// <response code="400">No se pudo eliminar el tipo de movimiento por la razon detallada.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        // DELETE api/<TipoMovimientoController>/5
        [HttpDelete("{tipoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipoMovimientoDto> EliminarTipo(int tipoId)
        {
            try
            {
                if (tipoId > 0)
                {
                    this._eliminarTipoMovimientoCU.EliminarTipo(tipoId);
                    return Ok($"Tipo de Movimiento con Id {tipoId} borrado correctamente");
                }
                return BadRequest("El Id debe ser un numero positivo");
            }
            catch (TipoMovimientoInvalidoException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error, no se ha encontrado el tipo que desea eliminar.");
            }
        }
    }
}
