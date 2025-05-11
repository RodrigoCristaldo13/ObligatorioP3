namespace Ejercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mesa mesa1 = new Mesa(id: 1, largo: 150, ancho: 80, altura: 75, material: "Madera", precio: 350);

            // Imprimir los datos de la mesa en pantalla
            Console.WriteLine(mesa1.ToString());

            Console.ReadKey();
        }
    }
}