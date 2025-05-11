namespace Primera_Prueba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try //si no funciona algo ya va al catch directamente
            {
                Console.WriteLine("Ingrese su nombre");
                string nombre = Console.ReadLine();
                //Console.WriteLine("Su nombre es: " + nombre);
                Console.WriteLine($"Su nombre es: {nombre}");


            }
            catch (Exception j)
            {
                Console.WriteLine("Ingrese correctamente el nombre");
                Console.WriteLine(j.Message);

            }

            try
            {
                Console.WriteLine("Ingrese su edad");
                int edad = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"Su edad es: {edad}");
            }
            catch (Exception e)
            {
                Console.WriteLine("La edad esta incorrecta");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();

        }
    }
}