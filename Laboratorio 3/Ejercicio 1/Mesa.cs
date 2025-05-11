using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    public class Mesa
    {
        public int Id {  get; set; }
        public static int UltimoId { get; set; } = 1;
        public Material Material { get; set; }  

        public double Largo { get; set; }   
        public double Ancho { get; set; }
        public double Altura { get; set;}
        public double Precio { get; set;}


        public Mesa()
        {
            Id = UltimoId;
            UltimoId++;
        }


        public Mesa(int id, Material m, double largo, double ancho, double altura, double precio)
        {
            Id = UltimoId;
            UltimoId++;
            Id = id;
            Material = m;
            Largo = largo;
            Ancho = ancho;
            Altura = altura;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"El precio de la mesa es: {Precio} y el material es: {Material.Nombre}" ;
        }



        
    }
}
