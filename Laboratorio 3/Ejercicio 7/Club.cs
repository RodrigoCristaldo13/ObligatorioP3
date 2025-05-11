using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    public class Club
    {
        public int Id { get; set; }
        public static int UltimoId {get;set;} = 1;
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int AnioFundacion { get; set; }

        public Club() 
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Club(int id, string nombre, string pais, int anioFundacion)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Pais = pais;
            AnioFundacion = anioFundacion;
        }

        public override string ToString()
        {
            return $"Club: {Nombre}, País: {Pais}, Año de Fundación: {AnioFundacion}";
        }
    }
}

