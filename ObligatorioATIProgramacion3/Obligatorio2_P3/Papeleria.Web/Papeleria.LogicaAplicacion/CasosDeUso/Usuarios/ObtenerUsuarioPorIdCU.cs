using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Administrador;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class ObtenerUsuarioPorIdCU : IObtenerUsuarioPorId
    {
        private IRepositorioUsuario _repositorioUsuarios;

        public ObtenerUsuarioPorIdCU(IRepositorioUsuario repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public UsuarioDto ObtenerUsuario(int id)
        {
            try
            {
                Usuario usuario = this._repositorioUsuarios.FindById(id);
                UsuarioDto usuarioDto = UsuarioDtoMapper.ToDto(usuario);
                return usuarioDto;
            }
            catch (PedidoInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
