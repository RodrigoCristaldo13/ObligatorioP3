namespace Ejercicio_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opciones = -1;

            while (opciones != 0)
            {
                Console.Clear(); // primero limpia y luego muestra opciones
                Console.WriteLine("1- Opción 1");
                Console.WriteLine("2- Opción 2");
                Console.WriteLine("0- Salir");

                try
                {
                    opciones = Int32.Parse(Console.ReadLine());

                    if (opciones == 1)
                    {
                        Console.WriteLine("La opcion seleccionada es 1");
                    }
                    else if (opciones == 2)
                    {
                        Console.WriteLine("La opcion seleccionada es 2");
                    }

                    Console.ReadKey();
                }
                catch (Exception e) //la e es la variable para mostrar luego un mensaje
                {
                    Console.WriteLine("Debe ingresar un numero");
                    Console.ReadKey();
                }


            }
        }
    }
}