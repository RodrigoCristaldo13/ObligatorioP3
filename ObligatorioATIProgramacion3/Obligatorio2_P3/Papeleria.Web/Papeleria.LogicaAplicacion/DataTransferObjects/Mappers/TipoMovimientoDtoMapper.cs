using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.Mappers
{
    public class TipoMovimientoDtoMapper
    {
        public static TipoMovimiento FromDto(TipoMovimientoDto TipoMovimientoDto)
        {
            try
            {
                if (TipoMovimientoDto == null) throw new TipoMovimientoInvalidoException("El Tipo de Movimiento no se pudo agregar");
                return new TipoMovimiento
                {
                    Id = TipoMovimientoDto.Id,
                    Nombre = TipoMovimientoDto.Nombre,
                    EstadoStock = TipoMovimientoDto.EstadoStock,
                };
            }
            catch (TipoMovimientoInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static TipoMovimientoDto ToDto(TipoMovimiento TipoMovimiento)
        {
            try
            {
                if (TipoMovimiento == null) throw new TipoMovimientoInvalidoException("Tipo de Movimiento inexistente");
                return new TipoMovimientoDto
                {
                    Id = TipoMovimiento.Id,
                    Nombre = TipoMovimiento.Nombre,
                    EstadoStock = TipoMovimiento.EstadoStock
                };
            }
            catch (TipoMovimientoInvalidoException e)
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
