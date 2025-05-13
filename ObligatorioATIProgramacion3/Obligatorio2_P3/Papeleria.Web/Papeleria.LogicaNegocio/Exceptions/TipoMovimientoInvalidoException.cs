using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions
{
    public class TipoMovimientoInvalidoException : Exception
    {
        public TipoMovimientoInvalidoException()
        {
        }

        public TipoMovimientoInvalidoException(string? message) : base(message)
        {
        }
    }
}
