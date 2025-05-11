using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_4
{
    public class Socio
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string  Nombre { get; set; }
        public string Email { get; set; }

        public Socio() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Socio( string nombre, string email)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Email = email;
        }   

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre se socio no puede estar vacio");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("El email del socio no puede estar vacio");
            }

          
        }

        public void MostrarSocio()
        {
            Console.WriteLine($"ID del socio: {Id}, Nombre: {Nombre}, Email: {Email}");
           


        }
    }
}
