using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_4
{
    public class Automovil
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnioFabricacion { get; set; }
        public Dueño Dueño { get; set; }

        public Automovil() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Automovil(string marca, string modelo, int anioFabricacion, Dueño dueño) 
        {
            Id = UltimoId;
            UltimoId++;
            Marca = marca;
            Modelo = modelo;
            AnioFabricacion = anioFabricacion;
            Dueño = dueño;
        }

        public override string ToString()
        {
            return $"El id del auto es: {Id}, la marca del auto es: {Marca}, el modelo es: {Modelo} y el año de fabricacion es: {AnioFabricacion}";
        }
    }
}
