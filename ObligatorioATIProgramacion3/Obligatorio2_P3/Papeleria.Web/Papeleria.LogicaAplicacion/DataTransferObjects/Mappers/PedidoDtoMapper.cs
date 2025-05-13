using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Enum;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.Mappers
{
    public class PedidoDtoMapper
    {
        public static Pedido DtoAComun(PedidoDto pedidoDto)
        {
            try
            {
                if (pedidoDto == null) throw new PedidoInvalidoException("El pedido no se pudo agregar");
                Cliente cliente = ClienteDtoMapper.FromDto(pedidoDto.Cliente);
                PedidoComun pedidoComun = new PedidoComun
                {
                    Id = pedidoDto.Id,
                    Cliente = cliente, // Solo agregamos el cliente para poder acceder a su distancia para calcular Recargo
                    FechaPedido = DateTime.Now,
                    FechaEntregaPrometida = pedidoDto.FechaEntregaPrometida,
                    IdCliente = pedidoDto.IdCliente,
                    Recargo = pedidoDto.Recargo,
                    MontoTotal = pedidoDto.MontoTotal
                };
                if (pedidoDto.LineasPedido != null && pedidoDto.LineasPedido.Count() > 0)
                {
                    pedidoComun.LineasPedido = LineaPedidoDtoMapper.LineasFromDto(pedidoDto.LineasPedido);
                }
                return pedidoComun;
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

        public static Pedido DtoAExpress(PedidoDto pedidoDto)
        {
            try
            {
                if (pedidoDto == null) throw new PedidoInvalidoException("El pedido no se pudo agregar");
                PedidoExpress pedidoExpress = new PedidoExpress
                {
                    Id = pedidoDto.Id,
                    FechaPedido = DateTime.Now,
                    FechaEntregaPrometida = pedidoDto.FechaEntregaPrometida,
                    IdCliente = pedidoDto.IdCliente,
                    Recargo = pedidoDto.Recargo,
                    MontoTotal = pedidoDto.MontoTotal
                };
                if (pedidoDto.LineasPedido != null && pedidoDto.LineasPedido.Count() > 0)
                {
                    pedidoExpress.LineasPedido = LineaPedidoDtoMapper.LineasFromDto(pedidoDto.LineasPedido);
                }
                return pedidoExpress;
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

        public static PedidoDto ToDto(Pedido pedido)
        {
            try
            {
                if (pedido == null) throw new PedidoInvalidoException(nameof(pedido));
                PedidoDto pedidoDto = new PedidoDto
                {
                    Id = pedido.Id,
                    FechaPedido = pedido.FechaPedido,
                    FechaEntregaPrometida = pedido.FechaEntregaPrometida,
                    IdCliente = pedido.IdCliente,
                    Recargo = pedido.Recargo,
                    Cliente = ClienteDtoMapper.ToDto(pedido.Cliente),
                    MontoTotal = pedido.MontoTotal,
                    Estado = pedido.Estado.ToString(),
                };
                if (pedido.LineasPedido != null && pedido.LineasPedido.Count() > 0)
                {
                    pedidoDto.LineasPedido = LineaPedidoDtoMapper.LineasToDto(pedido.LineasPedido);
                }
                return pedidoDto;
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
