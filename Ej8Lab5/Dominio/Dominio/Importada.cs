using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public  class Importada: Obra
    {
        public double PrecioPresentacion { get; set; }

        public Importada()
        {

        }
        public Importada(string nombre, double precioPresentacion) : base(nombre)
        {
            PrecioPresentacion = precioPresentacion;
        }

       
        public override void Validar()
        {
            base.Validar();
            //TODO validar
        }
    }
}
