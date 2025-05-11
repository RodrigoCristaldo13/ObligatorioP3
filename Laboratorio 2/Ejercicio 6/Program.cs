namespace Ejercicio_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pelicula pelicula1 = new Pelicula(id: 1, nombre: "Titanic", director: "Ana Perez", duracion: 85);
            Pelicula pelicula2 = new Pelicula(id: 2, nombre: "El Experimento", director: "Juan Lopez", duracion: 45);

            Console.WriteLine(pelicula1.ToString());
            Console.WriteLine($"Tipo: {pelicula1.TipoDePelícula()}");

            Console.WriteLine(pelicula2.ToString());
            Console.WriteLine($"Tipo: {pelicula2.TipoDePelícula()}");

            Console.ReadKey();  
        }
    }
}