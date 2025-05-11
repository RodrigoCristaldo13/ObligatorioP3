using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    public class Futbolista
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Club ClubJuega { get; set; }

        public Futbolista() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Futbolista( string nombre, string apellido, DateTime fechaNacimiento, Club club)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            ClubJuega = club;
        }

        public override string ToString()
        {
            return $"Futbolista: {Nombre} {Apellido}, Fecha de Nacimiento: {FechaNacimiento}, Club: {ClubJuega.Nombre}";
        }
    }
}

