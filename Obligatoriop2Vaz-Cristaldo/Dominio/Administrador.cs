using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador: Usuario
    {
        public Administrador()
        {

        }

        public Administrador(string email, string contrasenia) : base(email,contrasenia)
        {

        }

        public void BloquearUsuario(Miembro m)
        {
            if (m != null)
            {
                m.Bloqueado = true;
            }
        }

      
     
        public void CensurarPost(Post p)
        {
            if (p != null)
            {
                p.Censurado = true;
            }
        }

      

        
        
    }
}
