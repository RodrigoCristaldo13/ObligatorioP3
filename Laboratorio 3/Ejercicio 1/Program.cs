namespace Ejercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Material m1 = new Material("Madera", "Turquia");
            Material m2 = new Material("Marmol", "Venezuela");

            Mesa mesa1 = new Mesa // lo mismo que hacer en la misma linea
            {
                Altura = 1,
                Ancho = 5,
                Largo = 2,
                Precio = 5000,
                Material = m1,
            };

            Console.WriteLine(mesa1);
            Console.WriteLine("y el pais de origen del material es : " + mesa1.Material.PaisOrigen);


            
            
            
            
            
            
            
            Console.ReadKey();
        }

        
    }
}