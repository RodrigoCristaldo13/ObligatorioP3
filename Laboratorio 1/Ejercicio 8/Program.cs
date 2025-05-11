using System.ComponentModel.Design;

namespace Ejercicio_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opciones = -1;


            while (opciones != 0)
            {



               
                Console.WriteLine("Elegí una moneda destino: ");
                Console.WriteLine("1- Peso Argentino");
                Console.WriteLine("2- Dolar");
                Console.WriteLine("3- Euro");
                Console.WriteLine("4- Real");
                Console.WriteLine("0- Salir");

                try
                {
                    opciones = Int32.Parse(Console.ReadLine());

                    if (opciones >= 1 && opciones <= 4)
                    {
                        Console.WriteLine("Ingrese monto en Pesos Uruguayos");
                        double monto = Double.Parse(Console.ReadLine());

                        switch (opciones)
                        {
                            case 1:
                                Console.WriteLine($"El monto en Pesos Argentinos es: {monto * 9.26}");
                                break;
                            case 2:
                                Console.WriteLine($"El monto en Dolares es: {monto * 0.026}");
                                break;
                            case 3:
                                Console.WriteLine($"El monto en Euros es: {monto * 0.024}");
                                break;
                            case 4:
                                Console.WriteLine($"El monto en Reales es: {monto * 0.13}");
                                break;
                        }
                    }
                    else if (opciones == 0)
                    {
                        Console.WriteLine("Saliendo...");
                        Console.ReadKey();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Opcion invalida");
                    Console.ReadKey();
                }
            }
        }
    }
}