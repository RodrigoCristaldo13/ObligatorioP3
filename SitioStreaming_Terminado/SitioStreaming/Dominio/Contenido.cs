using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Contenido:IValidable
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Genero { get; set; }
        public static double PrecioBase { get; set; } = 100;

        protected Contenido( string titulo, int anio, string genero)
        {
            Id = UltimoId;
            UltimoId++;
            Titulo = titulo;
            Anio = anio;
            Genero = genero;
        }

        public virtual void Validar()
        {
            ValidarTitulo();
            ValidarAnio();
            ValidarGenero();
        }

        private void ValidarGenero()
        {
            if (string.IsNullOrEmpty(Genero))
            {
                throw new Exception("Debe ingresar un género");
            }
        }

        private void ValidarAnio()
        {
            if (Anio <= 0)
            {
                throw new Exception("Debe ingresar un año válido");
            }
        }

        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(Titulo))
            {
                throw new Exception("Debe ingresar un título");
            }
        }

        public abstract double CalcularPrecio();

        public override bool Equals(object obj)
        {
            return obj is Contenido contenido &&
                   Titulo == contenido.Titulo &&
                   Anio == contenido.Anio;
        }

        public abstract string GetTipo();
    }
}
