namespace Ejercicio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pais p1 = new Pais("Estados Unidos","USA");
            Director d1 = new Director ("Roberto", "Rodriguez", p1);
            Pelicula pel1 = new Pelicula("Titanic", new DateTime(2000, 02, 10), 180, d1, Genero.Terror);

            Console.WriteLine(pel1.Titulo);
            Console.WriteLine(pel1.Director.Pais.Nombre);
            Console.WriteLine(pel1.FechaBaja().ToShortDateString());
            Console.WriteLine(pel1.EsApta());

            Console.ReadKey();  
    


        }
    }
}