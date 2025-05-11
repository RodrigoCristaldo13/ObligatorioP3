namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Ingrese un número");
            int numero1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el otro número");
            int numero2 = Int32.Parse(Console.ReadLine());

            if (numero1 > numero2)
            {
                int numeroAux = numero1;
                numero1 = numero2;
                numero2 = numeroAux;
            }


            bool encontrado = false;
            for (int i = numero1; i <= numero2 && !encontrado; i++)
            {
                if (i % 33 == 0)
                {
                    Console.WriteLine("El primer multiplo de 33 es: " + i);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró");
            }


            Console.ReadKey();
        }
    }
}