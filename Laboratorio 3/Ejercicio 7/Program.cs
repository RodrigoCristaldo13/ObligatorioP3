namespace Ejercicio_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Club club1 = new Club(1, "Club A", "País A", 1920);

           
            Futbolista futbolista1 = new Futbolista("Juan", "Gomez", new DateTime(1990, 5, 15), club1);

            
            Gol gol1 = new Gol(futbolista1, 45, true, false);

            //  los datos
            Console.WriteLine(futbolista1);
            Console.WriteLine(club1);
            Console.WriteLine(gol1);

            Console.ReadKey();
        }
    }
}