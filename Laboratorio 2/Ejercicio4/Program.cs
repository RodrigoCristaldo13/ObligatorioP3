namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estadio estadio1 = new Estadio(id: 1, nombre: "Estadio A", capacidad: 50000);
            Estadio estadio2 = new Estadio(id: 2, nombre: "Estadio B", capacidad: 30000);

   
            int espectadoresEstadio1 = 55000;
            int espectadoresEstadio2 = 25000;

            bool porEncimaEstadio1 = estadio1.EstaPorEncimaDeCapacidad(espectadoresEstadio1);
            bool porDebajoEstadio2 = estadio2.EstaPorDebajoDeCapacidad(espectadoresEstadio2);

         
            Console.WriteLine(estadio1.ToString());
            Console.WriteLine($"¿Por encima de la capacidad?: {porEncimaEstadio1}");

            Console.WriteLine(estadio2.ToString());
            Console.WriteLine($"¿Por debajo de la capacidad?: {porDebajoEstadio2}");

            Console.ReadKey();
        }
    }
}
    
