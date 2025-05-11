using Dominio;
using System;
using System.Collections.Generic;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.Instancia();


            int opcion = -1;

            while(opcion != 0)
            {
                Console.Clear();
                Console.WriteLine("Ingrese una opción");
                Console.WriteLine("1- Listar Películas");
                Console.WriteLine("2- Listar Series");
                Console.WriteLine("3- Dado un monto listar compras que lo superen");
                Console.WriteLine("0- Salir");

                opcion = Int32.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        List<Pelicula> listaPeliculas = s.GetPeliculas();
                        foreach (Pelicula p in listaPeliculas)
                        {
                            Console.WriteLine(p.Titulo);
                            Console.WriteLine("------");
                        }
                    
                        break;

                    case 2:
                        List<Serie> listaSeries = s.GetSeries();
                        foreach (Serie serie in listaSeries)
                        {
                            Console.WriteLine(serie.Titulo);
                            Console.WriteLine("------");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Ingrese un monto");
                        double monto = double.Parse(Console.ReadLine());

                        List<Compra> listaCompras = s.GetComprasPorMonto(monto);

                        foreach (Compra compra in listaCompras)
                        {
                            Console.WriteLine(compra.Contenido.Titulo + " " + compra.Precio);
                            Console.WriteLine("---------");
                        }
                        break;
                }


                Console.ReadKey();
            }



          
        }
    }
}
