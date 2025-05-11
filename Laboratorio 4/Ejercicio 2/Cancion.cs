using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio_2
{
    public class Cancion
    {
        public double Duracion { get; set; }
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }


        public Cancion()
        {
            Id = UltimoId;
            UltimoId++;

        }

        public Cancion(double duracion, string nombre)
        {
            Id = UltimoId;
            UltimoId++;
            Duracion = duracion;
            Nombre = nombre;
        }


        public void Validar()
        {
            try
            {
                ValidarNombre();
            }
            catch (Exception )
            {
                throw;
            }
        }

        private void ValidarNombre()
        {
            if(string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }




        public override string ToString() 
        {
            return $"la duracion de la cancion es: {Duracion} y el nombre es: {Nombre}" ;
        }
    }
}
