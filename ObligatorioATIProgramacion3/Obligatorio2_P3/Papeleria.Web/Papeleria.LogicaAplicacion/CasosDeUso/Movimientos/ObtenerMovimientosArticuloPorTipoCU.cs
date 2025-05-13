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
    public class ObtenerMovimientosArticuloPorTipoCU : IObtenerMovimientosArticuloPorTipo
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        private IRepositorioConfiguracion _repositorioConfiguracion;

        public ObtenerMovimientosArticuloPorTipoCU(
            IRepositorioMovimiento repositorioMovimiento,
            IRepositorioConfiguracion repositorioConfiguracion)
        {
            _repositorioMovimiento = repositorioMovimiento;
            _repositorioConfiguracion = repositorioConfiguracion;
        }

        public IEnumerable<MovimientoDto> ObtenerMovimientosArticuloPorTipo(int idArticulo, string tipo, int numPag)
        {
            try
            {
               
                double cantidad = _repositorioConfiguracion.ObtenerValorConfigPorNombre("TopeMaxPorPagina");
             
                IEnumerable <MovimientoDto> movsReturn = _repositorioMovimiento.MovimientosArticuloPorTipo(idArticulo, tipo, numPag, cantidad).Select(m => MovimientoDtoMapper.ToDto(m)).ToList();
                if (movsReturn.Any())
                {
                    return movsReturn;
                }
                throw new MovimientoInvalidoException($"No se encontraron movimientos de tipo {tipo} para el articulo de Id {idArticulo}");
            }
            catch (MovimientoInvalidoException e)
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
