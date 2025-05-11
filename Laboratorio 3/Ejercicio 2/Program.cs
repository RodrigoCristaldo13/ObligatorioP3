using System.Numerics;

namespace Ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PaisOrigen p1 = new PaisOrigen("Uruguay", "URU");
            Marca m1 = new Marca("JVC", p1);
            Televisor t1 = new Televisor("Model3",Tamano.XL,true,"off", 95,m1);
            
    
          
            

            Console.ReadKey();  


        }
    }
}