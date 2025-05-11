using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    public class Torta
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public double Peso { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public double Precio { get; set; }
        private List<Ingrediente> _ingrediente {  get; }= new List<Ingrediente>();


        public Torta()
        {
            Id = UltimoId;
            UltimoId++;
            FechaFabricacion = DateTime.Now;
        }

        public Torta( string nombre, double peso, double precio)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Peso = peso;
            FechaFabricacion = DateTime.Now;
            Precio = precio;
           
        }

        public override string ToString()
        {
            return $"el nombre de la torta es: {Nombre}, el peso es: {Peso}";
        }


        public void AgregarIngrediente(Ingrediente i)
        {
            try
            {

                    i.Validar();
                    _ingrediente.Add(i);
                
            }
            catch (Exception e) 
            {
                throw;         
            }
        }

        

        public List<Ingrediente>GetIngrediente()
        {
            return _ingrediente;
        }


        


        public DateTime FechaVencimiento()
        {
            return FechaFabricacion.AddDays(20);

        }

        public double CalcularPrecio ()
        {
            
          TimeSpan tiempoParaQueVenza = FechaVencimiento() - DateTime.Now;  //guardo en un timespan
          TimeSpan cincoDias = new TimeSpan(5, 0, 0, 0); //elijo dias, horas, minutos y segundos
          

            if(DateTime.Now > FechaVencimiento()) // esta vencido
            {
                return 0;
            }
            if(tiempoParaQueVenza >= cincoDias) // esta bien de fecha
            {
                return Precio;
            }
            else
            {
                return Precio / 2; // retorno el 50% porque esta a menos de 5 dias
            }

           }
        



    }
}
