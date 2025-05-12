using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioMovimiento : IRepositorio<Movimiento>
    {
        public IEnumerable<Movimiento> MovimientosArticuloPorTipo(int idArticulo, string tipo, int numPag, double cantidad);
        public IEnumerable<Articulo> ArticulosConMovimientosEntreFechas(string fechaDesde, string fechaHasta, int numPag, double cantidad);
        public bool ExisteMovimientoDeTipo(int tipoId);
    }
}
