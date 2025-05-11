namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = new Sistema();//Esto está mal, debo tener Singleton

            foreach (Persona p in s.GetPersonas())
            {
                Console.WriteLine(p.Nombre + "- " + p.Email);
            }


            Console.ReadKey();
        }
    }
}