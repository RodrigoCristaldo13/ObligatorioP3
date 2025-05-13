using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Administradores;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class ObtenerUsuarioPorCorreoCU : IObtenerUsuarioPorCorreo
    {
        private IRepositorioUsuario _repositorioUsuario;
        public ObtenerUsuarioPorCorreoCU(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public UsuarioDto ObtenerUsuario(string correo)
        {
            Usuario usuario = _repositorioUsuario.ObtenerUsuario(correo);
            UsuarioDto usuarioDto = UsuarioDtoMapper.ToDto(usuario);
            return usuarioDto;
        }

        //public UsuarioDto ObtenerAdmin(string correo)
        //{
        //    Administrador administrador = _repositorioUsuario.ObtenerAdmin(correo);
        //    UsuarioDto usuarioDto = UsuarioDtoMapper.ToDto(administrador);
        //    return usuarioDto;
        //}
        //public UsuarioDto ObtenerEncargado(string correo)
        //{
        //    Encargado encargado = _repositorioUsuario.ObtenerEncargado(correo);
        //    UsuarioDto usuarioDto = UsuarioDtoMapper.ToDto(encargado);
        //    return usuarioDto;
        //}
    }
}
