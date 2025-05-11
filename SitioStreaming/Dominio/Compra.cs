using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Compra: IValidable
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public Socio Socio { get; set; }
        public Contenido Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public double Precio { get; set; }

        public Compra(Socio socio, Contenido contenido)
        {
            Id = UltimoId;
            UltimoId++;
            Socio = socio;
            Contenido = contenido;
            Fecha = DateTime.Now;
            Precio = 0;
        }

        public void CalcularPrecioFinal()
        {
            //TODO
        }

        public void Validar()
        {
          //TODO
        }
    }
}
