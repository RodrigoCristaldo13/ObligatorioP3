namespace Ejercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Ingrediente i1 = new Ingrediente("Canela","MonteCudine");
            Ingrediente i2 = new Ingrediente("Harina", "Cañuelas");
            Torta t1 = new Torta("Torta1", 12,  300);
            Torta t2 = new Torta("Torta2", 20,  500);

           
                t1.AgregarIngrediente(i1);
                t2.AgregarIngrediente(i2);

            

        

           

            foreach (Ingrediente i in t1.GetIngrediente()) 
                {
                //Console.WriteLine("Los ingredientes de la " + t2.Nombre + " son:" + i.Nombre + " de la marca :" + i.Marca);
                Console.WriteLine (i.ToString());   
                Console.WriteLine($"el precio de la torta es : {t1.CalcularPrecio()}  y la fecha de vencimiento es {t1.FechaVencimiento()}");
       


            }

            foreach (Ingrediente x in t2.GetIngrediente()) 
                {
                 
                   Console.WriteLine (x.ToString());
                Console.WriteLine($"el precio de la torta es : {t2.CalcularPrecio()} Y la fecha de vencimiento es: {t2.FechaVencimiento()}");
                    
                }
            
            Console.ReadKey();





        }
    }
}