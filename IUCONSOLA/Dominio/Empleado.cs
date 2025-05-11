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
            Id = UltimoId; // cada id se genera autoincremental para los hijos
            UltimoId++;

        }

        public Empleado(string nombre, string apellido)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
        }

        public abstract double CalcularSalario();   //  la clase tambien tiene que ser abstracta, para no darle implementacion. Puedo crear otros metodos no abtractos tambien

        //public virtual double CalcularSalario()  // sirve para tener implementacion en padre e hijos
        //{
        //return -1;
        //}


    }
}
