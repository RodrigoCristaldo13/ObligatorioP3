using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Pedidos
{
    public interface IObtenerPedidos
    {
        public IEnumerable<PedidoDto> ObtenerPedidosAnulados();
        public IEnumerable<PedidoDto> ObtenerPedidosPendientes(DateTime fecha);
    }
}
