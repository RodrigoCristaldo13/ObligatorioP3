using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Mascota : Ivalidable
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }


        public void Validar()
        {
            ValidarNombre();
            ValidarTipo();
        }


        public void ValidarNombre()
        {

        }

        public void ValidarTipo()
        {

        }

    }   



}
