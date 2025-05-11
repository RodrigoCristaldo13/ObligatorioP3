using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Empleado: Persona, Ivalidable
    {
        public int  NroEmpleado {  get; set; }

        public override void Validar()
        {
            base.Validar();
            ValidarNro();

        }
        private void ValidarNro()
        {

        }
    }
}
