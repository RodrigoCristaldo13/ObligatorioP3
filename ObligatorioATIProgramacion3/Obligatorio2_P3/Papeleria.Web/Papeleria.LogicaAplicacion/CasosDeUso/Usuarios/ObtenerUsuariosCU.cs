using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Administrador;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class ObtenerUsuariosCU : IObtenerUsuarios
    {
        private IRepositorioUsuario _repositorioUsuarios;

        public ObtenerUsuariosCU(IRepositorioUsuario repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public IEnumerable<UsuarioDto> ObtenerAdministradores()
        {
            IEnumerable<Administrador> admins = _repositorioUsuarios.ObtenerUsuariosAdministradores(); //POR EL MOMENTO MOSTRAMOS SOLO ADMINS PORQUE ES EL UNICO TIPO DE USUARIO
            return admins.Select(admin => UsuarioDtoMapper.ToDto(admin)).ToList();
        }

        public IEnumerable<UsuarioDto> ObtenerEncargados()
        {
            IEnumerable<Encargado> encargados = _repositorioUsuarios.ObtenerUsuariosEncargados(); //POR EL MOMENTO MOSTRAMOS SOLO ADMINS PORQUE ES EL UNICO TIPO DE USUARIO
            return encargados.Select(encargado => UsuarioDtoMapper.ToDto(encargado)).ToList();
        }

        public IEnumerable<UsuarioDto> ObtenerUsuarios()
        {
            IEnumerable<Usuario> usuarios = _repositorioUsuarios.FindAll(); //POR EL MOMENTO MOSTRAMOS SOLO ADMINS PORQUE ES EL UNICO TIPO DE USUARIO
            return usuarios.Select(usuario => UsuarioDtoMapper.ToDto(usuario)).ToList();
        }
    }
}
