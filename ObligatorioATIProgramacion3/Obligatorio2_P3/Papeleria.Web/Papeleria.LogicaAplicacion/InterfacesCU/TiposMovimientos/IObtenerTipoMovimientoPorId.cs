using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.TiposMovimientos
{
    public interface IObtenerTipoMovimientoPorId
    {
        public TipoMovimientoDto ObtenerTipoPorId(int id);
    }
}
