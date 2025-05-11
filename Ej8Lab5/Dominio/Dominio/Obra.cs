using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Obra : IValidable
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        private List<Personaje> _personajes = new List<Personaje>();

        public Obra(string nombre)
        {
            Id = _ultimoId;
            Nombre = nombre;

        }
        public Obra()
        {
            
        }
        public List<Personaje> GetPersonajes() { return _personajes; }
        public void AgregarPesonaje(Personaje p)
        {

            if (p != null)
            {
                _personajes.Add(p);

            }
        }

        public virtual void Validar()
        {
            //TODO validar
        }
    }
}
