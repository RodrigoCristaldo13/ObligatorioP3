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
    public class ObtenerMovimientosCU: IObtenerMovimientos
    {
        private IRepositorioMovimiento _repositorio;

        public ObtenerMovimientosCU(IRepositorioMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }

        public  IEnumerable<MovimientoDto> ObtenerMovimientos()
        {
            try
            {
                return _repositorio.FindAll().Select(mov => MovimientoDtoMapper.ToDto(mov)).ToList();
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
