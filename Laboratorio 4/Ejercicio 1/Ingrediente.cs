using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Marca { get; set; }


        public Ingrediente()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Ingrediente(string nombre, string marca)
        {
            Id = UltimoId;
            UltimoId++;
        Nombre= nombre;
        Marca= marca;

        }

        public override string ToString()
        {
            return $"el nombre del ingrediente es: {Nombre}, la marca es: {Marca}";
        }


        public void Validar()
        {
            try
            {
                ValidarNombre();
                ValidarMarca();
            }
            catch (Exception ) 
            {
                throw;
            }
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");

            }
        }

        private void ValidarMarca()
        {
            if (string.IsNullOrEmpty(Marca))

            {
                throw new Exception("La marca no puede estar vacia");
            }
        }
    }
}
