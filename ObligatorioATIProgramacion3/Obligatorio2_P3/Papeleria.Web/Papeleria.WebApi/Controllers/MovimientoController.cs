using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Configuraciones;
using Papeleria.LogicaAplicacion.InterfacesCU.Movimientos;
using Papeleria.LogicaNegocio.Exceptions;


namespace Papeleria.WebApi.Controllers
{
    [Route("api/Movimiento")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private IObtenerMovimientos _obtenerMovimientosCU;
        private IObtenerMovimientoPorId _obtenerMovimientoPorIdCU;
        private IAgregarMovimiento _agregarMovimientoCU;
        private IObtenerMovimientosArticuloPorTipo _obtenerMovimientosArticuloPorTipo;
        private IObtenerResumen _obtenerResumenCU;

        public MovimientoController(
            IObtenerMovimientos obtenerMovimientosCU,
            IObtenerMovimientoPorId obtenerMovimientoPorIdCU,
            IAgregarMovimiento agregarMovimientoCU,
            IObtenerMovimientosArticuloPorTipo obtenerMovimientosArticuloPorTipo,
            IObtenerResumen obtenerResumenCU)
        {
            _obtenerMovimientosCU = obtenerMovimientosCU;
            _obtenerMovimientoPorIdCU = obtenerMovimientoPorIdCU;
            _agregarMovimientoCU = agregarMovimientoCU;
            _obtenerMovimientosArticuloPorTipo = obtenerMovimientosArticuloPorTipo;
            _obtenerResumenCU = obtenerResumenCU;
        }

        /// <summary>
        /// Método que permite al usuario autenticado como Encargado del depósito obtener los movimientos existentes.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado por los encargados del depósito para consultar todos los movimientos registrados
        /// en el sistema. Es importante que el usuario esté autenticado y tenga los permisos necesarios para acceder
        /// a esta información.
        /// </remarks>
        /// <returns> Lista de movimientos existentes </returns>
        /// <response code="200">Devuelve la lista de movimientos existentes.</response>
        /// <response code="204">Devuelve un resultado exitoso pero avisa que la lista no tiene contenido.</response>
        /// <response code="401">No autorizado. El usuario no está autenticado o no tiene permisos suficientes.</response>
        /// <response code="403">El usuario no tiene los permisos necesarios para acceder a este recurso.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        // GET: api/<MovimientoController>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public ActionResult<IEnumerable<MovimientoDto>> ObtenerMovimientos()
        {
            try
            {
                IEnumerable<MovimientoDto> Movimientos = _obtenerMovimientosCU.ObtenerMovimientos();
                if (Movimientos != null && Movimientos.Count() > 0)
                {
                    return Ok(Movimientos);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "No se pudieron mostrar los movimientos");
            }
        }

        /// <summary>
        /// Método que permite obtener un Movimiento a traves de su ID.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado para consultar un Movimiento a traves de su ID. No se necesita autenticacion para acceder a esta información.
        /// </remarks>
        /// <returns> Movimiento con sus datos </returns>
        /// <response code="200">Devuelve el Movimiento.</response>
        /// <response code="400">Devuelve un error si el parametro de movId no cumple con lo establecido.</response>
        /// <response code="404">No existe un Movimiento con ese ID, no fue encontrado.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        // GET api/<MovimientoController>/5
        [HttpGet("{movId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MovimientoDto> ObtenerMovimientoPorId(int movId)
        {
            try
            {
                if (movId <= 0)
                {
                    return BadRequest("El Id debe ser un numero positivo");
                }
                MovimientoDto toReturn = this._obtenerMovimientoPorIdCU.ObtenerMovimientoPorId(movId);
                if (toReturn != null)
                {
                    return Ok(toReturn);
                }
                return NotFound();
            }
            catch (MovimientoInvalidoException e)
            {
                return NotFound($"No se encontro un Movimiento con id {movId} en nuestra base de datos");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error.");
            }
        }

        /// <summary>
        /// Método que permite al usuario autenticado como Encargado del depósito obtener los movimientos de un tipo dado y de un id articulo dado.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado por los encargados del depósito para consultar todos los movimientos registrados
        /// en el sistema que sean de un tipo especifico por ejemplo: "Venta" y que pertenezcan a un Articulo dado. 
        /// Es importante que el usuario esté autenticado y tenga los permisos necesarios para acceder a esta información.
        /// </remarks>
        /// <param name="idArticulo">Identificador del artículo.</param>
        /// <param name="tipo">Tipo de movimiento (por ejemplo, "Venta").</param>
        /// <param name="numPag">Numero de pagina que el usuario desea visualizar (Ej. 3)</param>
        /// <returns>
        /// Lista de movimientos existentes que coincidan con el tipo y el id articulo
        /// </returns>
        /// <response code="200">Devuelve la lista de movimientos existentes que cumplan con lo mencionado.</response>
        /// <response code="204">Devuelve un resultado exitoso pero avisa que la lista no tiene contenido.</response>
        /// <response code="400">Alguno de los parametros no cumple con lo establecido.</response>
        /// <response code="401">No autorizado. El usuario no está autenticado o no tiene permisos suficientes.</response>
        /// <response code="403">El usuario no tiene los permisos necesarios para acceder a este recurso.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        [HttpGet("Tipo/{tipo}/Articulo/{idArticulo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public ActionResult<MovimientoDto> ObtenerMovimientosArticuloPorTipo(int idArticulo, string tipo, int numPag)
        {
            try
            {
                if(numPag <= 0)
                {
                    numPag = 1;
                }
                if (idArticulo <= 0)
                {
                    return BadRequest("El Id de articulo debe ser un numero positivo");
                }
                if (String.IsNullOrEmpty(tipo))
                {
                    return BadRequest("El tipo de movimiento debe ser valido");
                }
                IEnumerable<MovimientoDto> toReturn = this._obtenerMovimientosArticuloPorTipo.ObtenerMovimientosArticuloPorTipo(idArticulo, tipo, numPag);
                return Ok(toReturn);
            }
            catch (MovimientoInvalidoException)
            {
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un problema al procesar la solicitud.");
            }
        }

        /// <summary>
        /// Método que permite al usuario autenticado como Encargado del depósito agregar un movimiento a la base de datos.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado por los encargados del depósito para agregar un movimiento a la base de datos.
        /// Es importante que el usuario esté autenticado y tenga los permisos necesarios para agregar un movimiento.
        /// </remarks>
        /// <returns>
        /// <returns> Agrega un nuevo movimiento a la Base de datos </returns>
        /// </returns>
        /// <response code="201">Resultado exitoso, Movimiento creado correctamente.</response>
        /// <response code="400">Algun dato del movimiento no cumple con el formato establecido.</response>
        /// <response code="401">No autorizado. El usuario no está autenticado o no tiene permisos suficientes.</response>
        /// <response code="403">El usuario no tiene los permisos necesarios para acceder a este recurso.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        // POST api/<MovimientoController>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public ActionResult<MovimientoDto> AgregarMovimiento([FromBody] MovimientoDto MovimientoDto)
        {
            try
            {
                this._agregarMovimientoCU.AgregarMovimiento(MovimientoDto);
                return Created("api/TipoMovimiento", MovimientoDto);
            }
            catch (MovimientoInvalidoException e)
            {
                return BadRequest($"Movimiento Invalido: {e.Message}");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error.");
            }
        }

        /// <summary>
        /// Método que permite al usuario autenticado como Encargado del depósito obtener un resumen de los movimientos de stock.
        /// </summary>
        /// <remarks>
        /// Este método es utilizado por los encargados del depósito para obtener un resumen de los movimientos de stock agrupados por año 
        /// y en cada año agrupado por Tipo de movimiento y la cantidad de aumento o reduccion de stock para ese tipo.
        /// Es importante que el usuario esté autenticado y tenga los permisos necesarios para acceder a esta información.
        /// </remarks>
        /// <returns>
        /// Listado con resumen de movimientos agrupados por año y tipo.
        /// </returns>
        /// <response code="200">Devuelve el listado correctamente.</response>
        /// <response code="204">Devuelve un resultado exitoso pero avisa que la lista no tiene contenido.</response>
        /// <response code="401">No autorizado. El usuario no está autenticado o no tiene permisos suficientes.</response>
        /// <response code="403">El usuario no tiene los permisos necesarios para acceder a este recurso.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        [HttpGet("Resumen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public ActionResult<IEnumerable<ResumenDto>> ObtenerResumen()
        {
            try
            {
                IEnumerable<ResumenDto> Resumen = _obtenerResumenCU.ObtenerResumen();
                if (Resumen != null && Resumen.Count() > 0)
                {
                    return Ok(Resumen);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "No se pudo obtener el resumen.");
            }
        }



    }
}
