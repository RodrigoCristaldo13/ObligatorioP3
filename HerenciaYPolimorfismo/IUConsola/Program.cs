using Dominio;

namespace IUConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FALTA LA CLASE SISTEMA
            
            //Empleado e = new Empleado("Ana", "Rodriguez");
            Jornalero j = new Jornalero(10, 150, "Juan", "Pèrez");
            Efectivo e1 = new Efectivo(20000, true, "Jorge", "Gonzalez");

            List<Empleado> empleados= new List<Empleado>();

            empleados.Add(j);
            empleados.Add(e1);
            //Console.WriteLine(e1.GetTipo()); 
            //Console.WriteLine(j.GetTipo());

            foreach (Empleado item in empleados)
            {
                if (item.GetTipo().Equals("Efectivo"))
                {
                    Efectivo efectivoAux = item as Efectivo;
                    Console.WriteLine("Soy un efectivo" + "Y mi sueldo mensual es: " + efectivoAux.SueldoMensual);
                }
                else if (item.GetTipo().Equals("Jornalero"))
                {
                    Jornalero jornaleroAux = (Jornalero) item;
                    Console.WriteLine("Soy un jornalero");
                }
            }


            Console.WriteLine(e1.CalcularSalario());
            Console.WriteLine(j.CalcularSalario());
            //Console.WriteLine(j.Saludar());

            Console.ReadKey();
        }
    }
}