using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.Interfaces;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    [Index(nameof(Email), IsUnique = true)]
    public abstract class Usuario : IValidable
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string Password { get; set; }
        public string PasswordEncriptada { get; set; }

        public void Validar()
        {
            ValidarEmail();
            ValidarNombreCompleto();
            ValidarPassword();
        }

        private void ValidarPassword()
        {
            try
            {
                if (String.IsNullOrEmpty(Password)) { throw new UsuarioInvalidoException("La contraseña no puede estar vacía."); }

                if (Password.Length < 6) { throw new UsuarioInvalidoException("La contraseña debe tener al menos 6 caracteres."); }

                // Verificamos si la contraseña contiene al menos una letra minúscula, una mayúscula, un dígito y un carácter de puntuación
                if (!Regex.IsMatch(Password, @"[a-z]")) { throw new UsuarioInvalidoException("La contraseña debe contener al menos una minúscula."); }
                if (!Regex.IsMatch(Password, @"[A-Z]")) { throw new UsuarioInvalidoException("La contraseña debe contener al menos una mayúscula."); }
                if (!Regex.IsMatch(Password, @"\d")) { throw new UsuarioInvalidoException("La contraseña debe contener al menos un dígito."); }
                if (!Regex.IsMatch(Password, @"[.,;!]")) { throw new UsuarioInvalidoException("La contraseña debe contener al menos un carácter de puntuación ( . ; , ! )."); }
            }
            catch (UsuarioInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al validar la contraseña.", ex);
            }
        }
        private void ValidarNombreCompleto()
        {
            try
            {
                if (NombreCompleto.Nombre.Length < 3)
                {
                    throw new UsuarioInvalidoException("El nombre es demasiado corto.");
                }

                if (NombreCompleto.Apellido.Length < 3)
                {
                    throw new UsuarioInvalidoException("El apellido es demasiado corto.");
                }

                if (String.IsNullOrEmpty(NombreCompleto.Nombre))
                {
                    throw new UsuarioInvalidoException("El nombre es requerido.");
                }

                if (String.IsNullOrEmpty(NombreCompleto.Apellido))
                {
                    throw new UsuarioInvalidoException("El apellido es requerido.");
                }

                if (!Regex.IsMatch(NombreCompleto.Nombre, @"^[a-zA-Z][a-zA-Z\s' -]*[a-zA-Z]$"))
                {
                    throw new UsuarioInvalidoException("El nombre acepta espacio en blanco, guion(-) o apostrofe(') pero no pueden estar al inicio o al final.");
                }

                if (!Regex.IsMatch(NombreCompleto.Apellido, @"^[a-zA-Z][a-zA-Z\s' -]*[a-zA-Z]$"))
                {
                    throw new UsuarioInvalidoException("El apellido acepta espacio en blanco, guion(-) o apostrofe(') pero no pueden estar al inicio o al final.");
                }
            }
            catch (UsuarioInvalidoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al validar el nombre completo.", ex);
            }
        }

        private void ValidarEmail()
        {
            try
            {
                if (String.IsNullOrEmpty(Email)) throw new UsuarioInvalidoException("El email no puede ser vacio y debe ser valido");
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

        public abstract override string ToString();
    }
}
