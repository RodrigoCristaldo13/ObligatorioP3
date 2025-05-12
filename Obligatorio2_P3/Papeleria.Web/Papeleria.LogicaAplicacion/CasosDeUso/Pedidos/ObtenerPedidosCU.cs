using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedidos
{
    public class ObtenerPedidosCU : IObtenerPedidos
    {
        private IRepositorioPedido _repositorioPedidos;

        public ObtenerPedidosCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedidos = repositorioPedido;
        }

        public IEnumerable<PedidoDto> ObtenerPedidosAnulados()
        {
            try
            {
                IEnumerable<Pedido> losPedidosAnulados = _repositorioPedidos.ObtenerPedidosAnulados();
                return losPedidosAnulados.Select(pedido => PedidoDtoMapper.ToDto(pedido)).ToList();
            }
            catch (PedidoInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<PedidoDto> ObtenerPedidosPendientes(DateTime fecha)
        {
            try
            {
                IEnumerable<Pedido> losPedidosPendientes = _repositorioPedidos.ObtenerPedidosPendientes(fecha);
                return losPedidosPendientes.Select(pedido => PedidoDtoMapper.ToDto(pedido)).ToList();
            }
            catch (PedidoInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
