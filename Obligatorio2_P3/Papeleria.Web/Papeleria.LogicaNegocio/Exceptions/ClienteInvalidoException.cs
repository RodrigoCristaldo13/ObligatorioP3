using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions
{
    public class ClienteInvalidoException : Exception
    {
        public ClienteInvalidoException()
        {
        }

        public ClienteInvalidoException(string? message) : base(message)
        {
        }
    }
}
