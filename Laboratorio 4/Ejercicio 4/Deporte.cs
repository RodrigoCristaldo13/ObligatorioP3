using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_4
{
    public class Deporte
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public bool AireLibre { get; set; }
        private List<Actividad>_actividades = new List<Actividad>();

        public Deporte()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Deporte(string nombre, bool airelibre)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            AireLibre = airelibre;
        }

        public void AgregarActividad(Actividad a)
        {
            try
            {
                if(a !=null)
                {
                    _actividades.Add(a);
                }
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            } 
        }

        public List<Actividad> GetActividades()
        {
            return _actividades;
        }

        public void ValidarDeporte()
        {
            if(string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre del deporte no puede estar vacio");
            }
        }


        public void MostrarDeporte()
        {
            Console.WriteLine($"ID del deporte: {Id}, el nombre es: {Nombre} y la actividad es al aire libre?: {AireLibre}");
        }


    }
}
