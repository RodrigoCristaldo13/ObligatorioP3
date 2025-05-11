using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Propia:Obra
    {
        public static double PrecioPresentacion = 10000;

        public Propia()
        {

        }
        public Propia(string nombre) : base(nombre)
        {
            
        }


        public override void Validar()
        {
            base.Validar();
            //TODO validar
        }
    }
}
