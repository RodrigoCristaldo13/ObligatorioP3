using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Presentacion: IValidable
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
      
        public double PrecioEntrada { get; set; }
        public Sala Sala { get; set; }
        public Obra Obra { get; set; }
        public bool EsBeneficio { get; set; }
        public int CantidadEntradas { get; set; }
        public double Recaudacion { get; set; }
        public Presentacion( DateTime fecha, double precioEntrada, Sala sala, Obra obra, bool esBeneficio)
        {
            Id = _ultimoId++;
            Fecha = fecha;
            PrecioEntrada = precioEntrada;
            Sala = sala;
            Obra = obra;
            EsBeneficio = esBeneficio;
            CantidadEntradas = 0;
            Recaudacion = 0;
        }

        public void Validar()
        {
            //TODO validar
        }
    }
}
