using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio_4
{
    public class Actividad
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Deporte Deporte { get; set; }
        public DateTime FechaYHora { get; set; }
        private List<Socio> _socios {  get; } = new List<Socio>();

        public Actividad()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Actividad(Deporte deporte, DateTime fechayhora)
        {
            Id = UltimoId;
            UltimoId++;
            FechaYHora = fechayhora;
            Deporte = deporte;


        }

        public void AgregarSocio(Socio s)
        {
            try
            {
                if (s != null)
                {
                    s.Validar();
                    _socios.Add(s);
                }
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public List<Socio> GetSocios()
        {
            return _socios;
        }

        public void ValidarActividad()
        {
            if (Deporte == null)
            {
                throw new Exception("La actividad debe tener un deporte que sea valido");
            }
            if(_socios.Count == 0)
            {
                throw new Exception("La actividad debe tener al menos un socio");
            }
        }

        public void MostrarActividad()
        {
            Console.WriteLine($"ID de la actividad: {Id}, el deporte es: {Deporte.Nombre} y la fecha de registro es: {FechaYHora}");
        }
    }
}
