using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sala: IValidable
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public Teatro Teatro { get; set; }


        public Sala( string nombre, int capacidad, Teatro teatro)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Capacidad = capacidad;
            Teatro = teatro;
        }
        public void Validar()
        {
            //TODO validar
        }
    }
}
