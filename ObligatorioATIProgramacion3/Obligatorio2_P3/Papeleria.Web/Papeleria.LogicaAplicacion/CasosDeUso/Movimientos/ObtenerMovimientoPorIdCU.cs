using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Movimientos;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Movimientos
{
    public class ObtenerMovimientosPorIdCU : IObtenerMovimientoPorId
    {
        private IRepositorioMovimiento _repositorio;
        public ObtenerMovimientosPorIdCU(IRepositorioMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }
        public MovimientoDto ObtenerMovimientoPorId(int id)
        {
            try
            {
                if (id < 1) { throw new MovimientoInvalidoException("Movimiento no encontrado"); }
                return  MovimientoDtoMapper.ToDto(_repositorio.FindById(id));
            }
            catch (MovimientoInvalidoException ex)
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
