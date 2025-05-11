using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Teatro : IValidable
    {

        private static int _ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        private List<Sala> _salas = new List<Sala>();
        public List<Sala> GetSalas() { return _salas; }
        public void AgregarSala(Sala sala)
        {
            if (sala != null)
            {
                _salas.Add(sala);
            }
        }

        public void Validar()
        {
            //TODO validar
        }

        public Teatro(string nombre)
        {
            Id = _ultimoId++;
            Nombre = nombre;

        }
    }
}
