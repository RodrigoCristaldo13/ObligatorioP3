using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Administrador
{
    public interface IAgregarUsuario
    {
        public void AgregarAdmin(UsuarioDto aAgregar);
        public void AgregarEncargado(UsuarioDto aAgregar);
    }
}
