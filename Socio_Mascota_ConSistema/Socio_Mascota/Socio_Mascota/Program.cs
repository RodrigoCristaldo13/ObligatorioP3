namespace Socio_Mascota
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sistema s = new Sistema();
            //Sistema s1 = new Sistema();
            Sistema s = Sistema.Instancia();



            //s.PrecargarDatos();

            Console.WriteLine("Ingrese nombre del socio");
            string nombreSocio = Console.ReadLine();

            Console.WriteLine("Ingrese apellido del socio");
            string apellidoSocio = Console.ReadLine();

            Socio socio = new Socio(nombreSocio, apellidoSocio);

            try
            {
                s.AltaSocio(socio);
                Console.WriteLine("Se agregó correctamente el socio");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            List<Mascota> listaFiltrada = s.GetPerros();

            if (listaFiltrada.Count > 0)
            {
                foreach (Mascota m in listaFiltrada)
                {
                    Console.WriteLine(m.Nombre);
                }
            }
            else
            {
                Console.WriteLine("No se encontraron mascotas de tipo perro");
            }



            Console.ReadKey();

        }
    }
}