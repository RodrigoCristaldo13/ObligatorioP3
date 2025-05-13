using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions
{
    public class ArticuloInvalidoException : Exception
    {
        public ArticuloInvalidoException()
        {

        }

        public ArticuloInvalidoException(string? message) : base(message)
        {

        }
    }
}
