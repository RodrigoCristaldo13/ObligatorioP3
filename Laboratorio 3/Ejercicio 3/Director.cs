using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3
{
    public class Director
    {

        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }  
        public string Apellido { get; set; }    
        public Pais Pais { get; set; }  


        public Director() 
        {
            Id = UltimoId;
            UltimoId++;
        }


        public Director(string nombre, string apellido, Pais pais)
        {

            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Pais = pais;
        }
    }
}
