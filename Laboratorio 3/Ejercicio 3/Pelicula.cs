using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3
{
    public class Pelicula
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;

        public string Titulo { get; set; }  
        public DateTime FechaLanzamiento { get; set; }  
        public int Duracion { get; set; }   
        public Director Director { get; set; }  

        public Genero Genero { get; set; }



        public Pelicula()
        {
            Id = UltimoId ;
            UltimoId++;
        }
         public Pelicula( string titulo, DateTime fechaLanzamiento, int duracion, Director director, Genero genero)
        {
            Id = UltimoId;
            UltimoId++;
            Titulo = titulo ;
            FechaLanzamiento = fechaLanzamiento;
            Duracion = duracion;
            Director = director;
            Genero = genero;
        }

        public DateTime FechaBaja()
        {

            return FechaLanzamiento.AddMonths(3);
        }

        public bool EsApta()
        {
            if(Genero == Genero.Suspenso || Genero == Genero.Terror || Genero == Genero.Thrilller) 
            {
                return false;
            }
            return true;
        }

    }
}
