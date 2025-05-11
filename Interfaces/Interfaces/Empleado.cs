using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Empleado:Persona
    {
        public Empleado(string nombre, string email) : base(nombre, email)
        {
        }

        public int NroEmpleado { get; set; }

        public override void Validar()
        {
            base.Validar();
            ValidarNro();
        }

        private void ValidarNro()
        {
            throw new NotImplementedException();
        }
    }
}
