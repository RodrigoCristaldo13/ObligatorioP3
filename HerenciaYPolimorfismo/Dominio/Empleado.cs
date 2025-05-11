using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Empleado
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Empleado()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Empleado(string nombre, string apellido)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
        }

        public abstract double CalcularSalario();

        //public virtual double CalcularSalario()
        //{
        //    return -1;
        //}

        public string Saludar()
        {
            return "hola soy empleado";
        }

        public abstract string GetTipo();


    }
}
