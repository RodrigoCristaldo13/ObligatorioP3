namespace Ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Artista a1 = new Artista("Luis Miguel", "Mexico");
            Artista a2 = new Artista("Julio Iglesias", "Uruguay");
            Album alb1 = new Album(" Album1", a1, 2023);
            Album alb2 = new Album("Album2", a2, 2012);

            alb1.AgregarCancion(new Cancion(4.5, " Cancion1"));
           
            alb1.AgregarCancion(new Cancion(2.5, "Canción 2"));

            alb2.AgregarCancion(new Cancion(3, "Canción 3"));
            alb2.AgregarCancion(new Cancion(3.5, "Canción 4"));

            // paso parametros directo de las canciones en los albumes

            double duracionAlb1 = alb1.CalcularDuracion();
            double duracionAlb2 = alb2.CalcularDuracion();

            foreach (Cancion c in alb1.GetCancion())
            {
                Console.WriteLine(c.ToString());
                Console.WriteLine($"Duración total de {alb1.Nombre}: {duracionAlb1} minutos");
            }

            foreach (Cancion i in alb2.GetCancion())
            {
                Console.WriteLine(i.ToString());
                Console.WriteLine($"Duración total de {alb2.Nombre}: {duracionAlb2} minutos");
            }

        }
    }
}