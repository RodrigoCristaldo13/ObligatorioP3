using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Movimientos;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Papeleria.LogicaAplicacion.DataTransferObjects.DTOs.ResumenDto;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Movimientos
{
    public class ObtenerResumenCU : IObtenerResumen
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        public ObtenerResumenCU(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public IEnumerable<ResumenDto> ObtenerResumen()
        {
            try
            {
                IEnumerable<MovimientoDto> movsDto = _repositorioMovimiento.FindAll().Select(m => MovimientoDtoMapper.ToDto(m));
                //agrupamos por año
                return movsDto
                    .GroupBy(m => m.Fecha.Year)
                    .Select(grupoAnio => new ResumenDto
                    {
                        Anio = grupoAnio.Key,
                        Detalles = grupoAnio.GroupBy(m => m.TipoMovimiento.Nombre)
                                                      .Select(grupoTipo => new DetalleResumenDto 
                                                      {
                                                          Tipo = grupoTipo.Key,
                                                          Cantidad = grupoTipo.Sum(m => m.Cantidad)
                                                      }).ToList(),
                        TotalAnio = grupoAnio.Sum(grupoTipo => grupoTipo.Cantidad)
                    })
                    .OrderByDescending(g => g.Anio)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
