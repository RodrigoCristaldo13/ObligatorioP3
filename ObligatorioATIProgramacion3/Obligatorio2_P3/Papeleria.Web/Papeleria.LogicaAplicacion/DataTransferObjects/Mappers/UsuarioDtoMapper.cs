using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.Mappers
{
    public class UsuarioDtoMapper
    {
        public static Administrador AdminFromDto(UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null) throw new UsuarioInvalidoException("El usuario no se pudo agregar");
                return new Administrador
                {
                    Id = usuarioDto.Id,
                    Email = usuarioDto.Email,
                    NombreCompleto = new NombreCompleto(usuarioDto.Nombre, usuarioDto.Apellido),
                    Password = usuarioDto.Password,
                    PasswordEncriptada = usuarioDto.PasswordEncriptada
                };
            }
            catch (UsuarioInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Encargado EncargadoFromDto(UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null) throw new UsuarioInvalidoException("El usuario no se pudo agregar");
                return new Encargado
                {
                    Id = usuarioDto.Id,
                    Email = usuarioDto.Email,
                    NombreCompleto = new NombreCompleto(usuarioDto.Nombre, usuarioDto.Apellido),
                    Password = usuarioDto.Password,
                    PasswordEncriptada = usuarioDto.PasswordEncriptada
                };
            }
            catch (UsuarioInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UsuarioDto ToDto(Usuario usuario)
        {
            try
            {
                if (usuario == null) throw new UsuarioInvalidoException(nameof(usuario));
                return new UsuarioDto
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Nombre = usuario.NombreCompleto.Nombre,
                    Apellido = usuario.NombreCompleto.Apellido,
                    Password = "**********",
                    PasswordEncriptada = usuario.PasswordEncriptada,
                    Rol = usuario.ToString()
                };
            }
            catch (UsuarioInvalidoException e)
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