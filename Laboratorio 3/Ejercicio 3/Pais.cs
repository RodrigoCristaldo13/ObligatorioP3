using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3
{
    public class Pais
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }  
        public string Codigo { get; set; }  

        public Pais()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Pais(string nombre, string codigo)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Codigo = codigo;
        }



    }



}
