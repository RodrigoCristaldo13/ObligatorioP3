using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Administrador;
using Papeleria.LogicaAplicacion.InterfacesCU.Encriptacion;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class ModificarUsuarioCU : IModificarUsuario
    {
        private IRepositorioUsuario _repositorioUsuarios;
        private IEncriptarPassword _encriptador;
        public ModificarUsuarioCU(
            IRepositorioUsuario repositorioUsuarios,
            IEncriptarPassword encriptador)
        {
            this._repositorioUsuarios = repositorioUsuarios;
            this._encriptador = encriptador;
        }

        public void ModificarAdmin(UsuarioDto aModificar)
        {
            //Probar
            try
            {
                aModificar.PasswordEncriptada = this._encriptador.Encriptar(aModificar.Password);
                Administrador admin = UsuarioDtoMapper.AdminFromDto(aModificar);
                this._repositorioUsuarios.Update(admin);
            }
            catch (Exception ex)
            {
                //Lanzar personalizada
                throw ex;
            }
        }

        public void ModificarEncargado(UsuarioDto aModificar)
        {
            //Probar
            try
            {
                aModificar.PasswordEncriptada = this._encriptador.Encriptar(aModificar.Password);
                Encargado encargado = UsuarioDtoMapper.EncargadoFromDto(aModificar);
                this._repositorioUsuarios.Update(encargado);
            }
            catch (Exception ex)
            {
                //Lanzar personalizada
                throw ex;
            }
        }
    }
}
