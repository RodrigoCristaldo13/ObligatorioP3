namespace Ejercicio10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un texto: ");
            string texto = Console.ReadLine();

            bool EmailValido = VerificarEmail(texto);

            if (EmailValido)
            {
                Console.WriteLine("El texto tiene formato de email válido.");
            }
            else
            {
                Console.WriteLine("El texto no tiene formato de email válido.");
            }

            Console.ReadKey();
        }

        static bool VerificarEmail(string texto) // para llamar la funcion dentro de la clase
        {
            if (texto.Length <= 1)
                return false;

            int posicionArroba = texto.IndexOf("@");
            int posicionUltimoArroba = texto.LastIndexOf("@");
            int posicionPunto = texto.IndexOf(".");
            int posicionUltimoPunto = texto.LastIndexOf(".");

            if (posicionArroba > 0 && posicionArroba < texto.Length - 1 &&
                posicionUltimoArroba == posicionArroba &&
                posicionPunto > 0 && posicionPunto < texto.Length - 1 &&
                posicionUltimoPunto == posicionPunto)
            {
                return true;
            }
            return false;

            
        }
    }
}