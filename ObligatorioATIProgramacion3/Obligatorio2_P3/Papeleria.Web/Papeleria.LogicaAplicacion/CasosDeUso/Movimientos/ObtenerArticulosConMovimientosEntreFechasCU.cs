using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Movimientos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Movimientos
{
    public class ObtenerArticulosConMovimientosEntreFechasCU : IObtenerArticulosConMovimientosEntreFechas
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        private IRepositorioConfiguracion _repositorioConfiguracion;

        public ObtenerArticulosConMovimientosEntreFechasCU(
            IRepositorioMovimiento repositorioMovimiento,
            IRepositorioConfiguracion repositorioConfiguracion)
        {
            _repositorioMovimiento = repositorioMovimiento;
            _repositorioConfiguracion = repositorioConfiguracion;
        }

        public IEnumerable<ArticuloDto> ObtenerArticulosConMovimientosEntreFechas(string fechaDesde, string fechaHasta, int numPag)
        {
            try
            {
                //obtener limite maximo por pagina
                double cantidad = _repositorioConfiguracion.ObtenerValorConfigPorNombre("TopeMaxPorPagina");
                //obtener los articulos con movimientos entre fechas especificas
                IEnumerable<ArticuloDto> articulosReturn = _repositorioMovimiento.ArticulosConMovimientosEntreFechas(fechaDesde, fechaHasta, numPag, cantidad).Select(a => ArticuloDtoMapper.ToDto(a)).ToList();
                //verificar si se encontraron
                if (articulosReturn.Any())
                {
                    return articulosReturn;
                }
                throw new ArticuloInvalidoException($"No se encontraron articulos en movimientos entre {fechaDesde} y {fechaHasta}");
            }
            catch (ArticuloInvalidoException e)
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
