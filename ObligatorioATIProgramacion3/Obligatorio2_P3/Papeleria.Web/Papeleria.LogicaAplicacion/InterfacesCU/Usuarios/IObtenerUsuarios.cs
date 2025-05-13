using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Administrador
{
    public interface IObtenerUsuarios
    {
        public IEnumerable<UsuarioDto> ObtenerAdministradores();
        public IEnumerable<UsuarioDto> ObtenerEncargados();
        public IEnumerable<UsuarioDto> ObtenerUsuarios();
    }
}
