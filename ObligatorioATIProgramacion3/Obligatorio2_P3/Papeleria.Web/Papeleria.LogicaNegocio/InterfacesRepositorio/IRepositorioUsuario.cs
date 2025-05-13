using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public Usuario ObtenerUsuario(string correo);
        public IEnumerable<Administrador> ObtenerUsuariosAdministradores();
        public IEnumerable<Encargado> ObtenerUsuariosEncargados();
    }
}
