using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions
{
    public class LineaPedidoInvalidoException : Exception
    {
        public LineaPedidoInvalidoException()
        {
        }

        public LineaPedidoInvalidoException(string? message) : base(message)
        {
        }
    }
}
