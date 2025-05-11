using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    public class Artista
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Pais {  get; set; }


        public Artista() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Artista( string nombre, string pais)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Pais = pais;
        }
    }
}
