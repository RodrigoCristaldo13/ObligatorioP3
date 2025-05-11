using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5
{
    public class Pais
    {
        private int _Id { get; set; }
        private string _Nombre { get; set; }
        private string _Codigo { get; set; }
        private string _Moneda { get; set; }
        private int _CantidadHabitantes { get; set; }
        private double _Area { get; set; }


        //el constructor a continuacion:

        public Pais(int id, string nombre, string código, string moneda, int cantidadHabitantes, double área)
        {
            _Id = id;
            _Nombre = nombre;
            _Codigo = código;
            _Moneda = moneda;
            _CantidadHabitantes = cantidadHabitantes;
            _Area = área;
        }

        //los metodos:

        public double Densidad()
        {
            return _CantidadHabitantes / _Area;
        }

        public override string ToString()
        {
            return $"País {_Id}: {_Nombre}, Código: {_Codigo}, Moneda: {_Moneda}, Habitantes: {_CantidadHabitantes}, Área: {_Area} km²";
        }
    }

}

