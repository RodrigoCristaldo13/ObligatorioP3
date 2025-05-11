using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Serie: Contenido
    {
        public int CantCap { get; set; }

        public Serie(int cantCap, string titulo, int anio, string genero):base(titulo,anio, genero)
        {
            CantCap = cantCap;
        }

        public override void Validar()
        {
            //TODO
        }

        public override double CalcularPrecio()
        {
            //TODO
            return -1;
        }
    }
}
