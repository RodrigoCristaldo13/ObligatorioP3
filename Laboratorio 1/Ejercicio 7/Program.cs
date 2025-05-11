namespace Ejercicio_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opciones = -1;

            while (opciones != 0)
            {
                Console.WriteLine("Elija una operacion : ");
                Console.WriteLine("1- Suma");
                Console.WriteLine("2- Resta");
                Console.WriteLine("3- Multiplicación");
                Console.WriteLine("4- Division");
                Console.WriteLine("0- Salir");



            try
                {
                    opciones = Int32.Parse(Console.ReadLine());

                    if (opciones >= 1 && opciones <= 4)

                    {
                        Console.WriteLine("Ingrese el primer numero");
                        double num1 = Double.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el segundo");
                        double num2 = Double.Parse(Console.ReadLine());

                        switch (opciones)
                        {
                            case 1:
                                Console.WriteLine($"El resultado es: {num1 + num2}");
                                break;
                            case 2:
                                Console.WriteLine($"El resultado es: {num1 - num2}");
                                break;
                            case 3:
                                Console.WriteLine($"El resultado es: {num1 * num2}");
                                break;
                            case 4:
                                if (num2 != 0)
                                    Console.WriteLine($"El resultado es: {num1 / num2}");
                                else
                                    Console.WriteLine("Imposible la division por cero.");
                                break;
                        }

                    }
                    else if(opciones == 0)
                    {
                        Console.WriteLine("Saliendo...");
                        Console.ReadKey();

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ingrese una opcion valida");
                    Console.ReadKey();
                }
            }


        }
    }
}