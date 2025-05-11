using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Email { get; set; }

        public Cliente()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Cliente(string nombre, string email)
        {
            Nombre = nombre;
            Email = email;
        }


    }
}
