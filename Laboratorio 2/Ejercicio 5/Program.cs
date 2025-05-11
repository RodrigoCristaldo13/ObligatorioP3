namespace Ejercicio_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pais país1 = new Pais(id: 1, nombre: "Uruguay", código: "UY", moneda: "Peso", cantidadHabitantes: 3500000, área: 1234567);

            Console.WriteLine(país1.ToString());
            Console.WriteLine($"Densidad: {país1.Densidad()} habitantes por km²");

            Console.ReadKey();  
        }
    }
}
