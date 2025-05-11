namespace Ejercicio_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = new Sistema();
            s.PrecargarDatos();

            Console.WriteLine("Lista de socios:");
            foreach (Socio socios in s.GetSocios()) 
            {
                socios.MostrarSocio();
            }

            Console.WriteLine("Lista de deportes: ");
            foreach (Deporte deportes in s.GetDeportes())
            {
                deportes.MostrarDeporte();
            }


            Console.WriteLine("Lista de actividades: ");
            foreach (Actividad actividades in s.GetActividades())
            {
                actividades.MostrarActividad();
                Console.WriteLine("Socios en esta actividad: ");
                foreach (Socio socio in actividades.GetSocios())
                {
                    socio.MostrarSocio();
                }
               
            }

            Console.ReadKey();  
        }
    }
}