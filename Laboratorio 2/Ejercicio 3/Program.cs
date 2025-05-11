namespace Ejercicio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
       
            Estudiante estudiante1 = new Estudiante(id: 1, nombre: "Juan", apellido: "Pérez", fechaNacimiento: new DateTime(2000, 5, 15), promedioAcademico: 98.5);
            Estudiante estudiante2 = new Estudiante(id: 2, nombre: "María", apellido: "Gómez", fechaNacimiento: new DateTime(2001, 10, 8), promedioAcademico: 89.2);

           
            Console.WriteLine(estudiante1.ToString());
            Console.WriteLine("Excelencia académica: " + (estudiante1.TieneExcelenciaAcademica() ? "Sí" : "No")); //

            Console.WriteLine(estudiante2.ToString());
            Console.WriteLine("Excelencia académica: " + (estudiante2.TieneExcelenciaAcademica() ? "Sí" : "No"));

            Console.ReadKey();  
        }
    }
    }
