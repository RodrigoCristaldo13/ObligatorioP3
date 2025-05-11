using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5
{
    internal class Animal
    {
        public int Id {  get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Raza { get; set; }
        public int Categoria { get; set; }
        public DateTime AnioNacimiento { get; set; }
        public int Peso { get; set; }
        public int NumeroDeCarne { get; set; }
        public Duenio Duenio { get; set; }
        public static double PrecioMensualidad { get; set; }
        public Animal() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Animal(string nombre, string tipo, string raza, int categoria, DateTime anioNacimiento, int peso, int numeroDeCarne, Duenio duenio)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Tipo = tipo;
            Raza = raza;
            Categoria = categoria;
            AnioNacimiento = anioNacimiento;
            Peso = peso;
            NumeroDeCarne = numeroDeCarne;
            Duenio = duenio;
        }

        public bool TratoPreferencial(string servicio)
        {
            if (Categoria >= 2)
            {
                if (servicio == "Banio" && Categoria >= 2)
                {
                    return true;
                }
                else if (servicio == "Manicura" && Categoria >= 3)
                {
                    return true;
                }
                else if (servicio == "Masaje" && Categoria >= 4)
                {
                    return true;
                }
                
            }
            return false; // predeterminado
        }

    }
}
