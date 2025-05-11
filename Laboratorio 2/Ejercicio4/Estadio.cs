using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio4
{
    public class Estadio
    {
        private int _Id { get; set; }
        private string _Nombre { get; set; }
        private int _Capacidad { get; set; }

        //constructor estadio

        public Estadio(int id, string nombre, int capacidad)
        {

            _Id = id;
            _Nombre = nombre;
            _Capacidad = capacidad;
        }
        //metodo 1
        public bool EstaPorEncimaDeCapacidad(int cantidadEspectadores)
        {
            return cantidadEspectadores > _Capacidad;
        }

        // metodo 2
        public bool EstaPorDebajoDeCapacidad(int cantidadEspectadores)
        {
            return cantidadEspectadores < _Capacidad;
        }

        // metodo 3, el override
        public override string ToString()
        {
            return $"Estadio {_Id}: {_Nombre}, Capacidad: {_Capacidad}";



        }
    }
}
