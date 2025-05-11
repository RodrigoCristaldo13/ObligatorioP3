namespace Ejercicio_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
         Dueño d1 = new Dueño("Rodrigo", "Cristaldo", new DateTime (1995, 02, 13));
         Automovil a1 = new Automovil("Fiat", "Uno", 2013, d1 );

         Console.WriteLine(a1.ToString());
        Console.WriteLine(d1.ToString());
            Console.ReadKey();
        }
    }
}