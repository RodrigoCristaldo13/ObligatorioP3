using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    public class Televisor
    {
        public int Id {  get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Modelo { get; set; }
        public Tamano Tamano { get; set; }
        public bool Smart {  get; set; }
        public string Estado { get; set; }
        public int Volumen {  get; set; }
        public Marca Marca { get; set; }



        public Televisor() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Televisor(string modelo, Tamano tamano, bool smart, string estado, int volumen, Marca marca)
        {
            Id = UltimoId;
            UltimoId++;
            Modelo = modelo;
            Tamano = tamano;
            Smart = smart;
            Estado = estado;
            Volumen = volumen;
            Marca = marca;

        }

       

    }
}
