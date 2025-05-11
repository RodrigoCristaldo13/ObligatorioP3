using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    public class PaisOrigen
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string NombreP { get; set; }
        public string Codigo { get; set; }


        public PaisOrigen ()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public PaisOrigen(string nombre, string codigo)
        {
            Id = UltimoId;
            UltimoId++;
            NombreP = nombre;
            Codigo = codigo;
        }
    }
}
