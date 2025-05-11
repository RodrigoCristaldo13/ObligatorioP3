using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public  class Actor: IValidable
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNac { get; set; }
        

        public Actor( string nombre, string apellido, string email, DateTime fechaNac)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            FechaNac = fechaNac;
        }

        public void Validar()
        {
         
        }
    }
}
