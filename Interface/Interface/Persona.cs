using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Persona : Ivalidable, IComparable<Persona> // debo agregar un metodo adentro si o si que sea Validar(), si tengo varias las agrego 
    {

        public string Nombre { get; set; }
        public string Email { get; set; }






        public int CompareTo(Persona other) //permite comparar instancia persona con otra
        {
            return Nombre.CompareTo(other.Nombre); // en este caso compara letras segun orden abecedario, (1 es mayor, -1 menor, igual 0)
            {

                //if(Nombre.CompareTo(other.......
                //   return 1;
                //}
                //else if(Nombre.CompareTo(other.Nombre)<0)
                //{
                //    return -1;
                //}
                //else
                //{
                //    return 0;
                //}
            }
        }


        public virtual void Validar()

        {
            ValidarNombre();
            ValidarEmail(); 

        }
        // agrego los metodos debajo

        public void ValidarNombre()
        {

        }
        public void ValidarEmail()
        {

        }
    }
}
