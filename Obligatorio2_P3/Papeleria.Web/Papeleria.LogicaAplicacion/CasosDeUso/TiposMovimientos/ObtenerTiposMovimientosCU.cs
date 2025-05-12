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
    public class ObtenerTiposMovimientosCU : IObtenerTiposMovimientos
    {
        private IRepositorioTipoMovimiento _repositorio;
        public ObtenerTiposMovimientosCU(IRepositorioTipoMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }

        public IEnumerable<TipoMovimientoDto> ObtenerTipos()
        {
            try
            {
                return _repositorio.FindAll().Select(tipo => TipoMovimientoDtoMapper.ToDto(tipo)).ToList();
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
