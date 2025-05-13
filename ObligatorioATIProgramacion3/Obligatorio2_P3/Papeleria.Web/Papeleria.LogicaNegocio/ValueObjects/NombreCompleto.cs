using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreCompleto 
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }

        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        protected NombreCompleto()
        {
            Nombre = "Sin nombre";
            Apellido = "Sin apellido";
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
