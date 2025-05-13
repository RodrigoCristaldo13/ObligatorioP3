using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions
{
    public class PedidoInvalidoException : Exception
    {
        public PedidoInvalidoException()
        {
        }

        public PedidoInvalidoException(string? message) : base(message)
        {
        }
    }
}
