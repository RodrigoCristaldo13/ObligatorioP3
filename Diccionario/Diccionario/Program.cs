using System;
using System.Collections.Generic;

namespace Diccionario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = new Sistema();
            Console.WriteLine("buscar un significado de palabra: ");
            string palabraBuscada = Console.ReadLine();
            Console.WriteLine("El significado es : " + s.BuscarSignificado(palabraBuscada));



            Console.WriteLine("\nBuscar palabras con subcadena: ");
            string subcadena = Console.ReadLine();

            List<string> palabrasConSubcadena = s.BuscarPorSubcadena(subcadena);
            Console.WriteLine("Palabras con subcadena: ");
            foreach (string palabra in palabrasConSubcadena)
            {
                Console.WriteLine(palabra);
            }


            Console.WriteLine("\nBuscar palabras con todas las vocales: ");



            List<string> palabrasConVocales = s.BuscarPalabrasConTodasLasVocales();
            Console.WriteLine("Palabras con todas las vocales: ");
            foreach (string palabra in palabrasConVocales)
            {
                Console.WriteLine(palabra);
            }




            Console.WriteLine("\nBuscar palabras más largas: ");
            List<string> palabrasMasLargas = s.BuscarPalabrasMasLargas();
            Console.WriteLine("Palabras más largas: ");
            foreach (string palabra in palabrasMasLargas)
            {
                Console.WriteLine(palabra);
            }




            Console.WriteLine("\nBuscar palabra con más consonantes: ");
            string palabraMasConsonantes = s.BuscarPalabraConMasConsonantes();
            Console.WriteLine("Palabra con más consonantes: " + palabraMasConsonantes);


            Console.ReadKey();
        }

    }
}

