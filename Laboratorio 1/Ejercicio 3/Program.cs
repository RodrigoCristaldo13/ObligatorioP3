namespace Ejercicio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese primer número");
            int numero1 = Int32.Parse(Console.ReadLine()); 

            Console.WriteLine("Ingrese segundo numero");
            int numero2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese tercer numero");
            int numero3 = Int32.Parse(Console.ReadLine());

            if (numero1 > numero2)
            {
                int numeroAux = numero1;
                numero1 = numero2;
                numero2 = numeroAux;
            }


            Console.WriteLine($"Los numeros multiplos del tercero son: "); //se muestra una vez sola


            for (int i = numero1; i <= numero2; i++)
            {
                if (i % numero3 == 0)
                {
                    Console.WriteLine(i); // muestra todos los numeros
                   
                }

            }

            Console.ReadKey();

        }
    }
}