namespace Ejercicio_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Televisor tv1 = new Televisor(id: 1, marca: "Samsung", modelo: "5", pulgadas: 55, esSmart: true);
            Televisor tv2 = new Televisor(id: 2, marca: "LG", modelo: "3", pulgadas: 32, esSmart: false);

            tv1.Encender();
            tv1.AjustarVolumen(50);
            tv2.Apagar();

          
            Console.WriteLine(tv1.ToString());
            Console.WriteLine(tv2.ToString());

            Console.ReadKey(); 
        }
    }
}