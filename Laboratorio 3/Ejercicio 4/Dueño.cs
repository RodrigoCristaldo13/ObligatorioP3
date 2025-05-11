using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_4
{
    public class Dueño
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Dueño() 
        {
            Id = UltimoId;
            UltimoId++;
        }
        
        public Dueño(string nombre, string apellido, DateTime fechanacimiento)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechanacimiento;
        }
        public override string ToString() 
        {
        return $"el id del dueno: {Id} con nombre: {Nombre} y apellido: {Apellido}, fecha de nacimiento: {FechaNacimiento.ToShortDateString()}";
        }
    }
}
