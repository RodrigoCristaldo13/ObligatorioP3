using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Jornalero : Empleado
    {
        public double HorasTrabajadas { get; set; }
        public double ValorHora { get; set; }

        public Jornalero(double horasTrabajadas, double valorHora, string nombre, string apellido) : base(nombre, apellido)
        {
            HorasTrabajadas = horasTrabajadas;
            ValorHora = valorHora;
        }

        public override double CalcularSalario()
        {
            return /*base.CalcularSalario() + */ValorHora * HorasTrabajadas;
        }

        public override string GetTipo()
        {
            return "Jornalero";
        }
    }
}
