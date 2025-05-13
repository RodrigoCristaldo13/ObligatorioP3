using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.Mappers
{
    public class LineaPedidoDtoMapper
    {
        public static LineaPedido FromDto(LineaPedidoDto lineaDto)
        {
            try
            {
                if (lineaDto == null) throw new LineaPedidoInvalidoException("La linea del pedido no se pudo agregar");
                Articulo articulo = ArticuloDtoMapper.FromDto(lineaDto.Articulo);
                
                return new LineaPedido
                {
                    Id = lineaDto.Id,
                    IdArticulo = lineaDto.IdArticulo,
                    CantidadUnidadesPedidas = lineaDto.CantidadUnidadesPedidas,
                    PrecioUnitarioVigente = lineaDto.PrecioUnitarioVigente
                };
            }
            catch (LineaPedidoInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static LineaPedidoDto ToDto(LineaPedido lineaPedido)
        {
            try
            {
                if (lineaPedido == null) throw new LineaPedidoInvalidoException("No se pudo obtener la linea del pedido");
                ArticuloDto articuloDto = ArticuloDtoMapper.ToDto(lineaPedido.Articulo);
                return new LineaPedidoDto
                {
                    Id = lineaPedido.Id,
                    IdArticulo = lineaPedido.IdArticulo,
                    Articulo = articuloDto,
                    CantidadUnidadesPedidas = lineaPedido.CantidadUnidadesPedidas,
                    PrecioUnitarioVigente = lineaPedido.PrecioUnitarioVigente
                };
            }
            catch (LineaPedidoInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<LineaPedidoDto> LineasToDto(List<LineaPedido> lineasPedido)
        {
            try
            {
                if (lineasPedido == null || lineasPedido.Count() <= 0) throw new LineaPedidoInvalidoException(nameof(lineasPedido));
                return lineasPedido.Select(pedido => LineaPedidoDtoMapper.ToDto(pedido)).ToList();
            }
            catch (LineaPedidoInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<LineaPedido> LineasFromDto(List<LineaPedidoDto> lineasPedidoDto)
        {
            try
            {
                if (lineasPedidoDto == null || lineasPedidoDto.Count() <= 0) throw new LineaPedidoInvalidoException(nameof(lineasPedidoDto));
                return lineasPedidoDto.Select(pedido => LineaPedidoDtoMapper.FromDto(pedido)).ToList();
            }
            catch (LineaPedidoInvalidoException e)
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
