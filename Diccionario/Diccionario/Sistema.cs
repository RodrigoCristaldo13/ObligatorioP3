using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Diccionario
{
    public class Sistema
    {
        List<Palabra> palabras = new List<Palabra>();
        public Sistema()
        {
            Precarga();
        }

        private void Precarga()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "/diccionario_espanol.txt";

            using (StreamReader file = new StreamReader(path))
            {
                int counter = 0;
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    string[] parts = ln.Split('#');
                    palabras.Add(new Palabra(parts[0], parts[1]));
                }
                file.Close();
            }
        }


        public string BuscarSignificado(string palabraBuscada)
        {
            foreach (Palabra palabra in palabras) // siempre recorro esto
            {
                if (string.Equals(palabra.Nombre, palabraBuscada, StringComparison.OrdinalIgnoreCase)) // para comparar de manera insensitive a mayusculas y minusculas
                {
                    return palabra.Significado;
                }
            }
            return "Palabra no encontrada";
        }

        public List<string> BuscarPorSubcadena(string subcadena)
        {
            List<string> resultados = new List<string>();

            foreach (Palabra palabra in palabras)
            {
                if (palabra.Nombre.IndexOf(subcadena, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    resultados.Add(palabra.Nombre);
                }
            }

            return resultados.Count > 0 ? resultados : new List<string> { "No se encontraron palabaras con lo escrito" };
        }

        public List<string> BuscarPalabrasConTodasLasVocales()
        {
            List<string> resultados = new List<string>();

            foreach (Palabra palabra in palabras)
            {
                string palabraEnMinusculas = palabra.Nombre.ToLower();
                if (palabraEnMinusculas.Contains("a") && palabraEnMinusculas.Contains("e") && palabraEnMinusculas.Contains("i") && palabraEnMinusculas.Contains("o") && palabraEnMinusculas.Contains("u"))
                {
                    resultados.Add(palabra.Nombre);
                }
            }
            return resultados.Count > 0 ? resultados : new List<string> { "No se encontraron resultados para ese pedido" };

        }

        public List<string> BuscarPalabrasMasLargas()
        {
            int maxLargo = 0;
            List<string> resultados = new List<string>();

            foreach (Palabra palabra in palabras)
            {
                int longitudPalabra = palabra.Nombre.Length;

                if (longitudPalabra > maxLargo)
                {
                    maxLargo = longitudPalabra;
                    resultados.Clear(); // esto borra los resultados anteriores si hay palabras mas largas
                }

                if (longitudPalabra == maxLargo)
                {
                    resultados.Add(palabra.Nombre);
                }
            }
            return resultados;
        }

        public String BuscarPalabraConMasConsonantes()
        {
            int maxConsonantes = 0;
            string resultados = "";

            foreach (Palabra palabra in palabras)
            {
                int cantidadConsonantes = ContarConsonantes(palabra.Nombre);

                if (cantidadConsonantes > maxConsonantes)
                {
                    maxConsonantes = cantidadConsonantes;
                    resultados = palabra.Nombre;
                }
                else if (cantidadConsonantes == maxConsonantes)
                {
                    resultados += "," + palabra.Nombre;
                }
            }
            return !string.IsNullOrEmpty(resultados)
                ? resultados
                : "No se encontraron";
        }


        public int ContarConsonantes (string palabra)
        {
            string consonantes = "bcdefghjklmnpqrstvwxyz";
            int contador = 0;

            foreach (char c in palabra.ToLower())
            {
                if (consonantes.Contains(c))
                {
                    contador++;
                }
            }
            return contador;
        }

    }

           
        }










    


    

