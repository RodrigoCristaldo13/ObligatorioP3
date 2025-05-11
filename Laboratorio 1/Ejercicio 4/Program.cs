namespace Ejercicio_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random numeroRandom = new Random();
            int numeroSecreto = numeroRandom.Next(1, 10000);

            bool encontrado = false;

            while (!encontrado)
            {
                Console.Clear();
                Console.WriteLine("ingrese numero:");
                int numeroIngresado = Int32.Parse(Console.ReadLine());

                if (numeroIngresado > numeroSecreto)
                {
                    Console.WriteLine("Menos");
                    Console.ReadKey();
                }
                else if (numeroIngresado < numeroSecreto)
                {
                    Console.WriteLine("Mas");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Número encontrado!!");
                    encontrado = true;
                }

            }
            Console.ReadKey();
        }
    }
}