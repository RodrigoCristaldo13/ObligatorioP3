namespace Ejercicio_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duenio duenio1 = new Duenio("Rodrigo", "4666871-5", 123456, "rjedn@hotmail.com", new DateTime (2023,07,23), Servicio.Masaje);
            Duenio duenio2 = new Duenio("Ari", "46525241-8", 9999, "holaan@hotmail.com", new DateTime(2021, 09, 23), Servicio.Banio);

            Animal animal1 = new Animal("Bruno", "Perro", "Labrador", 4, new DateTime(2015, 02, 21), 16, 545, duenio1);

            Animal animal2 = new Animal("Mia", "Gato", "Siames",2, new DateTime(2015, 02, 21), 9, 151, duenio2);




            bool tieneTratoBanio = animal1.TratoPreferencial("Banio");
            bool tieneTratoMasaje = animal2.TratoPreferencial("Masaje");



            
            Console.WriteLine($"el monto minimo para pagar es:  {Duenio.MontoMinimoPago}");
            double montoPago = 70.0;
            Console.WriteLine($"Monto de pago: {montoPago}");
            duenio1.RealizarPago(montoPago);


            if(duenio1.FechaUltimoPago != DateTime.MinValue)
            {
                Console.WriteLine($" Fecha del ultimo pago: {duenio1.FechaUltimoPago}");
            }
      



            Console.WriteLine("el animal " + animal1.Nombre + " tiene trato preferencial para banio? " +  tieneTratoBanio );
            Console.WriteLine("el animal " + animal2.Nombre + " tiene trato preferencial para masaje? " + tieneTratoMasaje);

            Console.ReadKey();  
        }
    }
}