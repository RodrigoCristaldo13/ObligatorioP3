using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions
{
    public class MovimientoInvalidoException : Exception
    {
        public MovimientoInvalidoException()
        {
        }

        public MovimientoInvalidoException(string? message) : base(message)
        {
        }
    }
}
