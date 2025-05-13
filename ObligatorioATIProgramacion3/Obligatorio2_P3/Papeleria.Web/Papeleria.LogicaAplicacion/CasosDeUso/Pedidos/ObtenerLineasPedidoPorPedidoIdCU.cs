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
    public class ObtenerLineasPedidoPorPedidoIdCU /* : IObtenerLineasPedidoPorPedidoId*/
    {
        //private IRepositorioPedido _repositorioPedido;
        //public ObtenerLineasPedidoPorPedidoIdCU(IRepositorioPedido repositorioPedido)
        //{
        //    _repositorioPedido = repositorioPedido;
        //}

        //public IEnumerable<LineaPedidoDto> ObtenerLineasPedido(int pedidoId)
        //{
        //    IEnumerable<LineaPedido> lineasDelPedidoActual = _repositorioPedido.ObtenerLineasPedidoPorPedidoId(pedidoId);

        //    return lineasDelPedidoActual.Select(lineaP => LineaPedidoDtoMapper.ToDto(lineaP));
        //}
    }
}
