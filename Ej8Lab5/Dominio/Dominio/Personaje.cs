using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Personaje: IValidable
    {
        public Actor Actor { get; set; }
        public string Papel { get; set; }
        public Personaje(Actor actor, string papel)
        {
            Actor = actor;
            Papel = papel;
        }
        public void Validar()
        {
            //TODO validar
        }
    }
}
