using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Jornalero : Empleado //quiere decir que jornalero hereda clase empleado
    {

    public double HorasTrabajadas {  get; set; }
        public double PrecioHora { get; set; }






        public Jornalero(double horasTrabajadas, double precioHora, string nombre, string apellido) : base(nombre, apellido) // base significa el padre
        {

            HorasTrabajadas = horasTrabajadas;
            PrecioHora = precioHora;

        }


        public override double CalcularSalario()
        {
            return CalcularSalario() + PrecioHora + HorasTrabajadas; // puedo sumar lo que retirna el padre al calcular mas lo que retorne los hijos al hacer sus calculos
        }









    }
    }

