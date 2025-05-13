using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.ValueObjects
{
    [Owned]
    public class Direccion
    {
        public string Calle { get; private set; }
        public int Numero { get; private set; }
        public string Ciudad { get; private set; }

        public Direccion()
        {
            Calle = "Sin calle";
            Numero = 0;
            Ciudad = "Sin Ciudad";
        }

        public Direccion(string calle, int numero, string ciudad)
        {
            Calle = calle;
            Numero = numero;
            Ciudad = ciudad;
        }
    }
}
