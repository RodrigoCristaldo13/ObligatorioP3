using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedidos
{
    public class AnularPedidoCU : IAnularPedido
    {
        private IRepositorioPedido _repositorioPedidos;

        public AnularPedidoCU(IRepositorioPedido repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public void AnularPedido(int id)
        {
            try
            {
                _repositorioPedidos.AnularPedido(id);
            }
            catch (PedidoInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
