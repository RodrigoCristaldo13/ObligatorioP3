using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Persona : IValidable, IComparable<Persona>
    {

        public string Nombre { get; set; }
        public string Email { get; set; }

        public Persona(string nombre, string email)
        {
            Nombre = nombre;
            Email = email;
        }

        //Establezco criterio de ordenamiento
        public int CompareTo(Persona other)
        {
            if(Nombre.CompareTo(other.Nombre) > 0)
            {
                return -1;
            }
            else if(Nombre.CompareTo(other.Nombre) < 0)
            {
                return 1;
            }
            else
            {
                if (Email.CompareTo(other.Email) > 0)
                {
                    return 1;
                }
                else if (Email.CompareTo(other.Email) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public virtual void Validar()
        {
            ValidarEmail();
            ValidarNombre();
        }

        public void ValidarNombre()
        {
            
        }

        private void ValidarEmail()
        {
            
        }
    }
}
