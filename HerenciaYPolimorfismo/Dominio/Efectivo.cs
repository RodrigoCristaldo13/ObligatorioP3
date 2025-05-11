using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Efectivo : Empleado
    {
        public double SueldoMensual { get; set; }
        public bool Presentismo { get; set; }

        public Efectivo(double sueldoMensual, bool presentismo, string nombre, string apellido):base(nombre, apellido) 
        {
            SueldoMensual = sueldoMensual;
            Presentismo = presentismo;
        }


        public override double CalcularSalario()
        {
            if (Presentismo)
            {
                return SueldoMensual + 1000;
            }
            return SueldoMensual;
        }

        public override string GetTipo()
        {
            return "Efectivo";
        }
    }
}
