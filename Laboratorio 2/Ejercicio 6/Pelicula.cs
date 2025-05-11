using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio_6
{
    public class Pelicula
    {
        private static int _DuracionAcuerdo { get; set;} = 60;
        private int _Id { get;  set; }
        private string _Nombre { get; set; }
        private string _Director { get; set; }
        private int _Duracion { get; set; }

        //ctor

        public Pelicula(int id, string nombre, string director, int duracion)
        {
            _Id = id;
            _Nombre = nombre;
            _Director = director;
            _Duracion = duracion;
        }

        //metodo

        public string TipoDePelícula()
        {
            return _Duracion >= _DuracionAcuerdo ? "Largometraje" : "Cortometraje";
        }

        public override string ToString()
        {
            return $"Pelicula {_Id}: {_Nombre}, Director: {_Director}, Duración: {_Duracion} minutos";
        }




    }
}
