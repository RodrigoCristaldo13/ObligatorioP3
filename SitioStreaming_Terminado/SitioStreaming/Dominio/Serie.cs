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
            base.Validar();
            ValidarCantidadCapitulos();
        }

        private void ValidarCantidadCapitulos()
        {
            if (CantCap <= 0)
            {
                throw new Exception("La cantidad de capítulos debe ser mayor a cero");
            }
        }

        public override double CalcularPrecio()
        {
            if (CantCap > 10)
            {
                return PrecioBase * 1.15;
            }
            else
            {
                return PrecioBase;
            }
        }

        public override string GetTipo()
        {
            return "Serie";
        }
    }
}
