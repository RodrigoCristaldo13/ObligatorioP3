namespace Ejercicio_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductoQuimico producto1 = new ProductoQuimico(id: 1, nombre: "Medicina A", activo: "Ibuprofeno", concentracion: 200.0, fechaFabricacion: new DateTime(2023, 1, 15));

            ProductoQuimico producto2 = new ProductoQuimico(id: 2, nombre: "Medicina B", activo: "Paracetamol", concentracion: 500.0, fechaFabricacion: new DateTime(2022, 9, 10));

            Console.WriteLine(producto1.ToString());
            Console.WriteLine($"Fecha de Vencimiento: {producto1.CalcularFechaVencimiento().ToShortDateString()}"); //presentacion de la fecha

            Console.WriteLine(producto2.ToString());
            Console.WriteLine($"Fecha de Vencimiento: {producto2.CalcularFechaVencimiento().ToShortDateString()}");

            Console.ReadKey();  
        }
    }
    }
