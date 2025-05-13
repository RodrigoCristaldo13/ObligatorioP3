using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Administradores;
using Papeleria.LogicaAplicacion.InterfacesCU.Encriptacion;
using Papeleria.LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class LoginUsuarioCU : ILoginUsuario
    {
        private IObtenerUsuarioPorCorreo _obtenerUsuarioPorCorreoCU;
        private IEncriptarPassword _encriptarPasswordCU;

        public LoginUsuarioCU(
            IObtenerUsuarioPorCorreo obtenerUsuarioPorCorreoCU,
            IEncriptarPassword encriptarPasswordCU)
        {
            this._obtenerUsuarioPorCorreoCU = obtenerUsuarioPorCorreoCU;
            _encriptarPasswordCU = encriptarPasswordCU;
        }

        public UsuarioDto Login(string correo, string password)
        {
            UsuarioDto usuarioDto = this._obtenerUsuarioPorCorreoCU.ObtenerUsuario(correo);
            if (usuarioDto != null)
            {
                password = _encriptarPasswordCU.Encriptar(password);
                if(usuarioDto.PasswordEncriptada == password)
                {
                    return usuarioDto;
                }
                else
                {
                    throw new UsuarioInvalidoException("La clave ingresada es incorrecta");
                }
            }
            else
            {
                throw new UsuarioInvalidoException("El usuario no se encuentra en nuestra base de datos!");
            }
        }
    }
}
