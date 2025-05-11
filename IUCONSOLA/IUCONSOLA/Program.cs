using Dominio;

namespace IUCONSOLA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           // Empleado e = new Empleado("Ana", "Rodriguez"); esto no se crea al ser abtsracta, creamos directo el efectivo o jornalero
            Jornalero j = new Jornalero(10, 150, "Juan", "Perez");
            Efectivo ef = new Efectivo(200, true, "Jorge", "Gonzalez");

            Console.WriteLine(ef.CalcularSalario());
            Console.WriteLine(j.CalcularSalario());


            Console.ReadKey();

    



        }
    }
}