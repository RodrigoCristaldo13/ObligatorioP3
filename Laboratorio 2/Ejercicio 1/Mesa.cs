using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    public class Mesa
    {
        private int _Id { get; set; }
        private double _Largo { get; set; }
        private double _Ancho { get; set; }
        private double _Altura { get; set; }
        private string _Material { get; set; }
        private decimal _Precio { get; set; }

        public Mesa(int id, double largo, double ancho, double altura, string material, decimal precio)
        {
            _Id = id;
            _Largo = largo;
            _Ancho = ancho;
            _Altura = altura;
            _Material = material;
            _Precio = precio;
        }

        public override string ToString()
        {
            return $"Mesa {_Id}: Dimensiones {_Largo} x {_Ancho} x {_Altura} cm, Material: {_Material}, Precio: {_Precio:C}";
        }

    }
}
