using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3
{
    public class Producto
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Activo { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaFabricacion { get; set; }

        public Producto() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Producto(string activo, int cantidad, DateTime fechaFabricacion, string nombre)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Activo = activo;
            Cantidad = cantidad;
            FechaFabricacion = fechaFabricacion;
        }

        public void EsValido()
        {
            if (string.IsNullOrEmpty(Activo) || string.IsNullOrEmpty(Nombre))
            {
                throw new Exception(" El nombre y el activo del producto no pueden estar vacios");
            }
            if(Cantidad <=0)
            {
                throw new Exception(" La cantidad del producto debe ser un valor numerico positivo");

            }
            DateTime fechaLimiteFabricacion = new DateTime(2021, 1, 1);
            TimeSpan diferencia = FechaFabricacion - fechaLimiteFabricacion;

            if (diferencia.TotalDays < 0)
            {
                throw new Exception(" La fecha de fabricacion debe ser posterior al 1 de enero de 2021");
            }



        }

        public void MostrarDatos()
        {
            Console.WriteLine("Clientes: ");
        }


    }
}
