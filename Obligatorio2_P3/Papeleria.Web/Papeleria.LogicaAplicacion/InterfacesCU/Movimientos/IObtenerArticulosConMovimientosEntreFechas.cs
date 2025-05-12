using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Movimientos
{
    public interface IObtenerArticulosConMovimientosEntreFechas
    {
        public IEnumerable<ArticuloDto> ObtenerArticulosConMovimientosEntreFechas(string fechaDesde, string fechaHasta, int numPag);
    }
}
