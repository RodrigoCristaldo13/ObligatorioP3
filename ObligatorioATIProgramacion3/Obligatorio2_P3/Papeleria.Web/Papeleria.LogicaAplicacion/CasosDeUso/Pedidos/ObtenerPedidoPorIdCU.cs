using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedidos
{
    public class ObtenerPedidoPorIdCU : IObtenerPedidoPorId
    {
        private IRepositorioPedido _repositorioPedidos;

        public ObtenerPedidoPorIdCU(IRepositorioPedido repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public PedidoDto ObtenerPedido(int id)
        {
            try
            {
                Pedido pedido = _repositorioPedidos.FindById(id);
                PedidoDto pedidoDto = PedidoDtoMapper.ToDto(pedido);
                return pedidoDto;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
