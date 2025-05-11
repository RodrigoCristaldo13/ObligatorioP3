using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pelicula: Contenido
    {
        public bool Estreno { get; set; }
        public int Duracion { get; set; }

     

        public Pelicula(bool estreno, int duracion, string titulo, int anio, string genero) : base (titulo, anio, genero)
        {
            Estreno = estreno;
            Duracion = duracion;
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
