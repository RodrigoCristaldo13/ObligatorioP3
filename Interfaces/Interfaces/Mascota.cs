using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Mascota : IValidable
    {

        public string Nombre { get; set; }
        public string Tipo { get; set; }


        public void Validar()
        {
            ValidarNombre();
            ValidarTipo();
        }

        private void ValidarTipo()
        {
            throw new NotImplementedException();
        }

        private void ValidarNombre()
        {
            throw new NotImplementedException();
        }
    }
}
