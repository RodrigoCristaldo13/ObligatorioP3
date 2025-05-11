Console.WriteLine("Ingrese un texto: "); // tuve que borrar el resto de la estructura no me permitia leer el string
string texto1 = Console.ReadLine(); 



Console.WriteLine($"La palabra en mayusculas es: {texto1.ToUpper()}");
Console.WriteLine($"La palabra en minusculas es: {texto1.ToLower()}");


string texto1Invertido = "";

for (int i=texto1.Length - 1; i>=0; i--)
{
   texto1Invertido += texto1[i];
}

Console.WriteLine($"El texto invertido es: {texto1Invertido}");
Console.ReadKey();
