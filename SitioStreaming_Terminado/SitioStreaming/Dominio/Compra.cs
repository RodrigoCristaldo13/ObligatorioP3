using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Compra : IValidable
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public Socio Socio { get; set; }
        public Contenido Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public double Precio { get; set; }
        //private string Estado { get; set; }
        

        public Compra(Socio socio, Contenido contenido)
        {
            Id = UltimoId;
            UltimoId++;
            Socio = socio;
            Contenido = contenido;
            Fecha = DateTime.Now;
            Precio = 0;
            //Estado = "Pendiente";
            CalcularPrecioFinal();
        }

        private void CalcularPrecioFinal()
        {
            //if(Estado == "Pendiente")
            //{
            //    Precio = Contenido.CalcularPrecio();
            //Estado = "Finalizado";
            //}

            if (Precio.Equals(0))
            {
                Precio = Contenido.CalcularPrecio();
            }

        }

        public void Validar()
        {
            if (Fecha > DateTime.Now)
            {
                throw new Exception("No se puede realizar una compra futura");
            }
            if (Socio == null)
            {
                throw new Exception("Debe ingresar un socio");
            }
            if (Contenido == null)
            {
                throw new Exception("Debe ingresar un contenido");
            }

        }
    }
}