using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    public class Televisor
    {
        public int _Id { get;  set; }
        public string _Marca { get; set; }
        public string _Modelo { get; set; }
        public double _Pulgadas { get; set; }
        public bool _EsSmart { get; set; }
        public bool _Estado { get;  set; } // true para encendido y false para apagado
        public int _NivelVolumen { get;  set; }
        
        //es el constructor
        public Televisor(int id, string marca, string modelo, double pulgadas, bool esSmart)
        {
            _Id = id;
            _Marca = marca;
            _Modelo = modelo;
            _Pulgadas = pulgadas;
            _EsSmart = esSmart;
            _Estado = false; //  comienza apagado
            _NivelVolumen = 0; //  comienza en 0
        }

      
        public void Encender()
        {
            _Estado = true;
        }
        public void Apagar()
        {
            _Estado = false;
        }

        public void AjustarVolumen(int nuevoVolumen)
        {
            if (nuevoVolumen >= 0 && nuevoVolumen <= 100)
            {
                _NivelVolumen = nuevoVolumen;
            }
        }

       
        public override string ToString()        //  datos del televisor
        {
            string estadoTexto = _Estado ? "Encendido" : "Apagado";
            return $"Televisor {_Id}: Marca {_Marca}, Modelo {_Modelo}, Pulgadas {_Pulgadas}, Smart: {_EsSmart}, Estado: {estadoTexto}, Volumen: {_NivelVolumen}";
        }
    }

}

