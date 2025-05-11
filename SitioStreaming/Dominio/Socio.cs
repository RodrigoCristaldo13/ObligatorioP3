using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Socio:IValidable
    {
        public static int UltimoId { get; set; }
        public  int Id { get; set; }
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public  string Cedula { get; set; }

        public Socio( string nombre, string apellido, string cedula)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
        }

        public void Validar()
        {
            //TODO
        }

        public override bool Equals(object obj)
        {
            return obj is Socio socio &&
                   Cedula == socio.Cedula;
        }
    }
}
