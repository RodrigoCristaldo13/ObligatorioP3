using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    public class Material
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }



        public Material() 
        {
            Id = UltimoId;
            UltimoId++;
        }


        public Material(string nombre, string paisOrigen)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            PaisOrigen = paisOrigen;


        }


    }
}
