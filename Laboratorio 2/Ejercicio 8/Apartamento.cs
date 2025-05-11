using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_8
{
    public class Apartamento
    {
        private static double _ValorBase = 100000; // este es el valor base en dólares
        private static double _PorcentajeDormitorios = 0.20; // este es el 20%
        private static double _PorcentajePisoSuperior = 0.05; // este es el  5%

        private int Numero { get;  set; }
        private int Cuartos { get; set; }
        private int Piso { get; set; }
        private bool VistaCalle { get; set; }

        //ctor

        public Apartamento(int numero, int cuartos, int piso, bool vistaCalle)
        {
            Numero = numero;
            Cuartos = cuartos;
            Piso = piso;
            VistaCalle = vistaCalle;
        }

        //metodos
        public double CalcularPrecio()
        {
            double precio = _ValorBase;

            if (Cuartos >= 2)
            {
                precio += _ValorBase * _PorcentajeDormitorios;
            }

            if (Piso >= 6)
            {
                precio += _ValorBase * _PorcentajePisoSuperior;
            }

            return precio;
        }


        public override string ToString()
        {
            string vista = VistaCalle ? "Vista a la calle" : "Vista interior";
            return $"Apartamento {Numero}: {Cuartos} cuartos, Piso {Piso}, {vista}";
        }
    }
}
