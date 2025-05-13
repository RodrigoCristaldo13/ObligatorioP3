using Papeleria.LogicaAplicacion.InterfacesCU.Administrador;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class EliminarUsuarioCU : IEliminarUsuario
    {
        private IRepositorioUsuario _repositorioUsuarios;
        public EliminarUsuarioCU(IRepositorioUsuario repositorioUsuarios)
        {
            this._repositorioUsuarios = repositorioUsuarios;
        }

        public void EliminarUsuario(int idAEliminar)
        {
            try
            {
                this._repositorioUsuarios.Remove(idAEliminar);
            }
            catch (UsuarioInvalidoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
