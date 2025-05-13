using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MovimientoDtoMapper
    {
        public static Movimiento FromDto(MovimientoDto MovimientoDto)
        {
            try
            {
                if (MovimientoDto == null) throw new MovimientoInvalidoException("El  Movimiento no se pudo agregar");
                return new Movimiento
                {
                    Id = MovimientoDto.Id,
                    Fecha = DateTime.Now,
                    IdArticulo = MovimientoDto.IdArticulo,
                    IdTipoMovimiento = MovimientoDto.IdTipoMovimiento,
                    EmailEncargado = MovimientoDto.EmailEncargado,
                    Cantidad = MovimientoDto.Cantidad
                };
            }
            catch (MovimientoInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static MovimientoDto ToDto(Movimiento Movimiento)
        {
            try
            {
                if (Movimiento == null) throw new MovimientoInvalidoException("Movimiento inexistente");
                ArticuloDto articulo = ArticuloDtoMapper.ToDto(Movimiento.Articulo);
                TipoMovimientoDto tipoMov = TipoMovimientoDtoMapper.ToDto(Movimiento.TipoMovimiento);
                return new MovimientoDto
                {
                    Id = Movimiento.Id,
                    Fecha = Movimiento.Fecha,
                    IdArticulo = Movimiento.IdArticulo,
                    Articulo = articulo,
                    IdTipoMovimiento = Movimiento.IdTipoMovimiento,
                    TipoMovimiento = tipoMov,
                    EmailEncargado = Movimiento.EmailEncargado,
                    Cantidad = Movimiento.Cantidad
                };
            }
            catch (MovimientoInvalidoException e)
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

