using Dominio;

namespace Obligatoriop2Vaz_Cristaldo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.Instancia();

            int opcion = -1;
            while (opcion != 0)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido");
                Console.WriteLine("1 - Alta Miembro");
                Console.WriteLine("2 - Mostrar Publicaciones de un Usuario");
                Console.WriteLine("3 - Mostrar Posts que contengan comentarios de un Usuario");
                Console.WriteLine("4 - Mostrar Posts entre fechas");
                Console.WriteLine("5 - Mostrar Miembro/s con más Publicaciones");
                Console.WriteLine("0 - Salir");

                Console.WriteLine("Seleccione una opción");
                opcion = Int32.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Ingrese su nombre");
                            string nombreUsuario = Console.ReadLine();
                            Console.WriteLine("Ingrese su apellido");
                            string apellidoUsuario = Console.ReadLine();
                            Console.WriteLine("Ingrese su fecha de nacimiento (DD/MM/AAAA)");
                            string fechaNacimiento = Console.ReadLine();
                            Console.WriteLine("Ingrese su email");
                            string emailUsuario1 = Console.ReadLine();
                            Console.WriteLine("Ingrese su nueva contraseña");
                            string passUsuario = Console.ReadLine();

                            s.NuevoMiembro(nombreUsuario, apellidoUsuario, fechaNacimiento, emailUsuario1, passUsuario);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Los datos no deben ser vacíos");
                        }
                        
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el mail del usuario:");
                        string emailUsuario = Console.ReadLine();
                        List<Publicacion> listaPublicaciones = s.ListarPostsUsuario(emailUsuario);
                        foreach (Publicacion p in listaPublicaciones)
                        {
                            Console.WriteLine(p.Titulo);
                            Console.WriteLine("------");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el mail del usuario:");
                        string emailUsuarioCaso2 = Console.ReadLine();
                        List<Publicacion> listaPublicacionesCaso2 = s.ListarPostConComentarioUsuarioSinComentario(emailUsuarioCaso2);
                        foreach (Publicacion p in listaPublicacionesCaso2)
                        {
                            Console.WriteLine(p.Titulo);
                            Console.WriteLine("------");

                        }

                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Ingrese una fecha(formato: DD/MM/AAAA:");

                        string fecha1 = Console.ReadLine();

                        Console.WriteLine("Ingrese una fecha(formato: DD/MM/AAAA:");

                        string fecha2 = Console.ReadLine();

                        //TODO
                        if (DateTime.TryParse(fecha1, out DateTime f1) && DateTime.TryParse(fecha2, out DateTime f2))
                        {
                            //funciona la conversion de fechas
                            List<Publicacion> ListapostEntreFechasCaso3 = s.ListarPostEntreFechas(f1, f2);
                            foreach (Publicacion p in ListapostEntreFechasCaso3)
                            {
                                Console.WriteLine(p.ToString());
                                Console.WriteLine("--------");

                            }
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        List<Miembro> ListaMiembroConMasPublicaciones = s.MiembroConMasPublicaciones();

                        if (ListaMiembroConMasPublicaciones.Count > 0)
                        {
                            Console.WriteLine("Miembros con mas publicaciones es: ");
                            foreach (Miembro m in ListaMiembroConMasPublicaciones)
                            {
                                Console.WriteLine(m.ToString());
                                Console.WriteLine("--------");
                            }
                        }

                        Console.ReadKey();
                        break;

                }
            }














        }
    }
}