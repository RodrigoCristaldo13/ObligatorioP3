using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.TiposMovimientos;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TiposMovimientos
{
    public class ObtenerTipoMovimientoPorIdCU : IObtenerTipoMovimientoPorId
    {
        private IRepositorioTipoMovimiento _repositorio;
        public ObtenerTipoMovimientoPorIdCU(IRepositorioTipoMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }

        public TipoMovimientoDto ObtenerTipoPorId(int id)
        {
            try
            {
                if (id < 1) { throw new TipoMovimientoInvalidoException("Tipo de Movimiento no encontrado"); }
                return TipoMovimientoDtoMapper.ToDto(_repositorio.FindById(id));
            }
            catch (TipoMovimientoInvalidoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
