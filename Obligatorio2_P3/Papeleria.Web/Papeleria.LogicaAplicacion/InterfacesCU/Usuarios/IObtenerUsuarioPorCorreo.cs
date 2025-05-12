using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Administradores
{
    public interface IObtenerUsuarioPorCorreo
    {
        public UsuarioDto ObtenerUsuario(string correo);
        //public UsuarioDto ObtenerAdmin(string correo);
        //public UsuarioDto ObtenerEncargado(string correo);
    }
}
