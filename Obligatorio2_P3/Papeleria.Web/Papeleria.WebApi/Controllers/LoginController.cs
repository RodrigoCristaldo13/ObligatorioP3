using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Administradores;
using Papeleria.LogicaNegocio.Exceptions;
using static Papeleria.LogicaAplicacion.DataTransferObjects.DTOs.UsuarioDto;

namespace Papeleria.WebApi.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginUsuario _loginUsuarioCU;
        public LoginController(ILoginUsuario loginUsuarioCU)
        {
            _loginUsuarioCU = loginUsuarioCU;
        }

        /// <summary>
        /// Metodo que permite iniciar sesion y obtener un token.
        /// </summary>
        ///  /// <remarks>
        /// Este método es utilizado para iniciar sesion en el sistema.
        /// </remarks>
        /// <param name="usuario">Usuario que desea iniciar sesion</param>
        /// <returns>Datos del usuario y Token</returns>
        /// <response code="200">Resultado exitoso para el inicio de sesion.</response>
        /// <response code="400">Fallo en el login por alguna razon que se especifica.</response>
        /// <response code="500">Error interno del servidor. Ocurrió un problema al procesar la solicitud.</response>
        /// [HttpPost]
        [HttpPost("")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioDto> Login([FromBody] UsuarioDto usuario)
        {
            try
            {
                //iniciar sesion
                UsuarioDto anonimo = _loginUsuarioCU.Login(usuario.Email, usuario.Password);
                if (anonimo != null)
                {
                    //si es encargado generar token JWT
                    if (anonimo.Rol == "Encargado")
                    {
                        var token = ManejadorJWT.GenerarToken(anonimo);
                        //retornar los datos del usuario y token si hay exito
                        return Ok(new
                        {
                            Token = token,
                            Id = anonimo.Id,
                            Nombre = anonimo.Nombre,
                            Apellido = anonimo.Apellido,
                            Email = anonimo.Email,
                            Password = anonimo.PasswordEncriptada,
                            Rol = anonimo.Rol,
                        });
                    }
                    return BadRequest("Solamente los Encargados de deposito pueden acceder.");
                }
                return BadRequest("Credenciales inválidas, reintente.");
            }
            catch (UsuarioInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Se produjo un error. Intente nuevamente.");
            }
        }
    }
}
