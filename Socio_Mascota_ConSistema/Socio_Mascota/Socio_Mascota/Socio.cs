using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio_Mascota
{
    public class Socio
    {

        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaUltimoPago { get; set; }
        
        //Siempre protejo la lista, haciéndola privada y sin set
        private List<Mascota> _mascotas { get; } = new List<Mascota>();

        public Socio()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Socio(string nombre, string apellido, DateTime fechaUltimoPago)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            FechaUltimoPago = fechaUltimoPago;
        }

        public Socio(string nombre, string apellido)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            FechaUltimoPago = DateTime.Now;
        }

        //Para poder agregar elementos a la lista creo un método para poder validar antes de agregar
        public void AgregarMascota(Mascota m)
        {
            try
            {
                if (m != null)
                {
                    m.Validar();
                    _mascotas.Add(m);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //Para poder acceder a los elementos de la lista creo un método
        public List<Mascota> GetMascotas()
        {
            return _mascotas;
        }

        public bool Aldia()
        {
            DateTime fechaHoy = DateTime.Now;
            DateTime haceUnMes = fechaHoy.AddMonths(-1);

            if (haceUnMes > FechaUltimoPago)
            {
                return false;
            }

            return true;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacio");
            }
        }
    }
}
