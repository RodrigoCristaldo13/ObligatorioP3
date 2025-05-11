namespace Ejercicio_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Apartamento apartamento1 = new Apartamento(numero: 101, cuartos: 2, piso: 5, vistaCalle: true);
            Apartamento apartamento2 = new Apartamento(numero: 202, cuartos: 3, piso: 8, vistaCalle: false);

            Console.WriteLine(apartamento1.ToString());
            Console.WriteLine($"Precio: {apartamento1.CalcularPrecio()} dólares");

            Console.WriteLine(apartamento2.ToString());
            Console.WriteLine($"Precio: {apartamento2.CalcularPrecio()} dólares");

            Console.ReadKey();  
        }
    }
    }
