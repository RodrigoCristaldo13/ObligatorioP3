using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Password { get; set; }
        public string? PasswordEncriptada { get; set; }
        public string? Rol { get; set; }
    }
}
