using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario: IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Email { get; set; }
        public string Contrasenia { get; set; }
    

        public Usuario()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Usuario(string email, string contrasenia)
        {
            Id = UltimoId;
            UltimoId++;
            Email = email;
            Contrasenia = contrasenia;
        }

        private void ValidarContrasenia()
        {
            if(string.IsNullOrEmpty(Contrasenia))
            {
                throw new Exception("La contrasenia no puede ser vacia");
            }
            if (Contrasenia.Length < 5)
            {
                throw new Exception("La contrasenia debe tener al menos 5 caracteres");
            }
        }

        private void ValidarEmail()
        {
            if(string.IsNullOrEmpty(Email))
            {
                throw new Exception("El mail no debe estar vacio");
            }
        }

        public virtual void Validar()
        {
            ValidarContrasenia();
            ValidarEmail();
        }

        public void Acceder() 
        {
        
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
