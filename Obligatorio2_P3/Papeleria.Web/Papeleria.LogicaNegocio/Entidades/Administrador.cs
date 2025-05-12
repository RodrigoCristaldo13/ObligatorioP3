using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Administrador : Usuario
    {
        public Administrador()
        {
        
        }

        public override string ToString()
        {
            return "Administrador";
        }
    }
}
