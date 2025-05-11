using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pelicula: Contenido
    {
        public bool Estreno { get; set; }
        public int Duracion { get; set; }

     

        public Pelicula(bool estreno, int duracion, string titulo, int anio, string genero) : base(titulo, anio, genero)
        {
            Estreno = estreno;
            Duracion = duracion;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarDuracion();
        }

        private void ValidarDuracion()
        {
            if (Duracion <= 0)
            {
                throw new Exception("Debe ingresar una duración válida");
            }
        }

        public override double CalcularPrecio()
        {
            if (Estreno)
            {
                return PrecioBase * 1.10;
            }
            else
            {
                return PrecioBase;
            }
        }

        public override string GetTipo()
        {
            return "Pelicula";
        }


    }
}
