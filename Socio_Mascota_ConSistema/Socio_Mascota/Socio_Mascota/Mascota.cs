using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio_Mascota
{
    public class Mascota
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Raza { get; set; }
        public DateTime FechaUltVacuna { get; set; }

        public Mascota()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Mascota(string nombre, string tipo, string raza, DateTime fechaUltVacuna)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Tipo = tipo;
            Raza = raza;
            FechaUltVacuna = fechaUltVacuna;
        }

        public DateTime ProximaVacuna()
        {
            return FechaUltVacuna.AddYears(1);
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarTipo();
        }

        

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacío");
            }
        }

        private void ValidarTipo()
        {
            if (string.IsNullOrEmpty(Tipo))
            {
                throw new Exception("El tipo no puede estar vacío");
            }
        }


    }
}
