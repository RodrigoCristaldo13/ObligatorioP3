using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Entidades;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioPedido : IRepositorio<Pedido>
    {
        public bool AnularPedido(int id);
        public IEnumerable<Pedido> ObtenerPedidosPendientes(DateTime fecha);
        public IEnumerable<Pedido> ObtenerPedidosAnulados();
        public IEnumerable<Cliente> ObtenerClientesMontoTotalMayorA(double montoTotal);
    }
}
