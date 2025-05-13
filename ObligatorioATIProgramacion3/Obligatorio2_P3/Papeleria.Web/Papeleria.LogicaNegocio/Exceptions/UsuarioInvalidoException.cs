using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions
{
    public class UsuarioInvalidoException : Exception
    {
        public UsuarioInvalidoException() 
        {
        
        }

        public UsuarioInvalidoException(string? message) : base(message)
        {

        }
    }
}
