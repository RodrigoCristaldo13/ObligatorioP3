using System;

namespace Ejercicio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Sistema s = new Sistema();
            s.PrecargarDatos();


            Console.WriteLine("Clientes:");
            foreach (Cliente cliente in s.GetClientes())
            {
                Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Fecha de Alta: {cliente.FechaAltaCliente}");
                Console.WriteLine("Productos asociados:");
                foreach (Producto producto in cliente.GetProductos())
                {
                    Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Cantidad: {producto.Cantidad}, Fecha de Fabricación: {producto.FechaFabricacion}");
                }
                Console.WriteLine();
            }

            // puedo agregar o no que el usuario ingrese datos y mostrarle un mensaje de exito

            Console.ReadKey();  
        }
    }
}