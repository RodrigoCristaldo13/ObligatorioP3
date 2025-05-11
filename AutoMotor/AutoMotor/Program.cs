namespace AutoMotor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Motor m1 = new Motor(1, 4); // 1 chasis y 4 cilindros


            Auto a1 = new Auto(m1);


            Console.WriteLine(a1);

            Console.WriteLine(a1.Motor.Cilindros); //muestro las propiedades del motor del auto a1


            Console.ReadKey();  
        }
    }
}