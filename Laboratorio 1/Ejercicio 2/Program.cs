namespace Ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese primer número");
            double numero1 = Double.Parse(Console.ReadLine()); //probando double para que incluya numeros decimales tambien

            Console.WriteLine("Ingrese segundo numero");
            double numero2 = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese tercer numero");
            double numero3 = Double.Parse(Console.ReadLine());


            if (numero1 > numero2)
            {
                double numeroAux = numero1;
                numero1 = numero2;
                numero2 = numeroAux;
            }


            bool encontrado = false;

            for (double i = numero1; i <= numero2 && !encontrado; i++)
            {
                if (i == numero3)
                {
                    Console.WriteLine("El tercer numero esta incluido entre los dos primeros");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("El tercer numero NO esta incluido entre los 2 primeros");
            }


            Console.ReadKey();
        }
    }
}