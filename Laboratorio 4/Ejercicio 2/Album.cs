using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    public class Album
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public Artista Artista { get; set; }
        public int Anio { get; set; }
        private List<Cancion> _cancion { get; } = new List<Cancion>();

        public Album()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Album(string nombre, Artista artista,int anio)
        {
            Id = UltimoId;
            UltimoId++;
            Anio = anio;
            Nombre = nombre;
            Artista = artista;
        }

        public void AgregarCancion(Cancion c)
        {
            try
            {
                c.Validar();
                _cancion.Add(c);
            }
            catch (Exception e) 
            {
                throw;
            }
            {
            
            }
        }

        public List<Cancion> GetCancion()
        {
            return _cancion;
        }



        public double CalcularDuracion()
        {
            double duracionTotal = 0;
            foreach (Cancion cancion in _cancion) //cancion en cada bucle se convierte en uno de los objetos Cancion en la lista _cancion
            {
                duracionTotal += cancion.Duracion;  // sumamos la duracion de la cancion actual en cada bucle a la variable duracionTotal.
            }
            return duracionTotal;
        }







        public override string ToString()
        {
            return $"el nombre del album es: {Nombre}, del artista : {Artista} y del anio {Anio}, sus canciones son:  ";
        }

    }
}
