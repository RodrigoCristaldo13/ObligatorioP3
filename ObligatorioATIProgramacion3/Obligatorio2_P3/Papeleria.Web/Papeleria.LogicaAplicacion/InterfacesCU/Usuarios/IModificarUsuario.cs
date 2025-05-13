using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Administrador
{
    public interface IModificarUsuario
    {
        public void ModificarAdmin(UsuarioDto aModificar);
        public void ModificarEncargado(UsuarioDto aModificar);

    }
}
