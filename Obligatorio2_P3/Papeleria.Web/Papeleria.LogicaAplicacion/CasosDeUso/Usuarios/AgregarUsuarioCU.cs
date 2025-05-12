using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Administrador;
using Papeleria.LogicaAplicacion.InterfacesCU.Encriptacion;
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
    public class AgregarUsuarioCU : IAgregarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        private IEncriptarPassword _encriptador;

        public AgregarUsuarioCU(
            IRepositorioUsuario repositorioUsuario,
            IEncriptarPassword encriptor)
        {
            this._repositorioUsuario = repositorioUsuario;
            this._encriptador = encriptor;
        }

        public void AgregarAdmin(UsuarioDto aAgregar)
        {
            try
            {
                aAgregar.PasswordEncriptada = this._encriptador.Encriptar(aAgregar.Password);
                Administrador admin = UsuarioDtoMapper.AdminFromDto(aAgregar);
                this._repositorioUsuario.Add(admin);
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

        public void AgregarEncargado(UsuarioDto aAgregar)
        {
            try
            {
                aAgregar.PasswordEncriptada = this._encriptador.Encriptar(aAgregar.Password);
                Encargado encargado = UsuarioDtoMapper.EncargadoFromDto(aAgregar);
                this._repositorioUsuario.Add(encargado);
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
