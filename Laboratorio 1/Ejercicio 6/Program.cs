using System.ComponentModel.Design;

namespace Ejercicio_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opciones = -1;

            

            while (opciones != 0)
            {
                
                Console.Clear(); // primero limpia y luego muestra opciones
                Console.WriteLine("Elegí un mes del año: ");
                Console.WriteLine("1- Enero");
                Console.WriteLine("2- Febrero");
                Console.WriteLine("3- Marzo");
                Console.WriteLine("4- Abril");
                Console.WriteLine("5- Mayo");
                Console.WriteLine("6- Junio");
                Console.WriteLine("7- Julio");
                Console.WriteLine("8- Agosto");
                Console.WriteLine("9- Setiembre");
                Console.WriteLine("10- Octubre");
                Console.WriteLine("11- Noviembre");
                Console.WriteLine("12- Diciembre");

                try
                {
                    
                    opciones = Int32.Parse(Console.ReadLine());

                    if (opciones == 1)
                    {
                        Console.WriteLine("En Enero hay 1 feriado");
                    }
                    else if (opciones == 2)
                    {
                        Console.WriteLine("En Febrero hay 2 feriados");
                    }
                    else if (opciones == 3)
                    {
                        Console.WriteLine("En Marzo hay 1 feriados");
                    }
                    else if (opciones == 4)
                    {
                        Console.WriteLine("En Abril hay 2 feriados");
                    }
                    else if (opciones == 5)
                    {
                        Console.WriteLine("En Mayo hay 3 feriados");
                    }
                    else if (opciones == 6)
                    {
                        Console.WriteLine("En Junio hay 3 feriados");
                    }
                    else if (opciones == 7)
                    {
                        Console.WriteLine("En Julio hay 1 feriados");
                    }
                    else if (opciones == 8)
                    {
                        Console.WriteLine("En Agosto hay 1 feriado");
                    }
                    else if (opciones == 9)
                    {
                        Console.WriteLine("En Setiembre hay O feriados");
                    }
                    else if (opciones == 10)
                    {
                        Console.WriteLine("En Octubre hay 2 feriados");
                    }
                    else if (opciones == 11)
                    {
                        Console.WriteLine("En Noviembre hay 1 feriados");
                    }
                    else if (opciones == 12)
                    {
                        Console.WriteLine("En Diciembre hay 2 feriados");
                    }
                   
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Debe ingresar una opcion valida");
                    Console.ReadKey();
                }
            }

        }      

            
    }
}