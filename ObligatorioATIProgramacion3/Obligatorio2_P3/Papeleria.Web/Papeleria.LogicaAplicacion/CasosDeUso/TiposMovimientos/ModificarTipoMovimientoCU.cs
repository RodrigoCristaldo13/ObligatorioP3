using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Movimientos;
using Papeleria.LogicaAplicacion.InterfacesCU.TiposMovimientos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TiposMovimientos
{
    public class ModificarTipoMovimientoCU : IModificarTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        private IExisteMovimientoDeTipo _existeMovimientoDeTipoCU;

        public ModificarTipoMovimientoCU(
            IRepositorioTipoMovimiento repositorioTipoMovimiento,
            IExisteMovimientoDeTipo existeMovimientoDeTipoCU)
        {
            _repositorioTipoMovimiento = repositorioTipoMovimiento;
            _existeMovimientoDeTipoCU = existeMovimientoDeTipoCU;
        }

        public void ModificarTipo(TipoMovimientoDto aModificar)
        {
            try
            {
                if (aModificar != null)
                {
                    if (_existeMovimientoDeTipoCU.ExisteMovimientoDeTipo(aModificar.Id))
                    {
                        throw new TipoMovimientoInvalidoException($"No se puede modificar el tipo de movimiento ya que está siendo utilizado en algun Movimiento.");
                    }
                    TipoMovimiento tipo = TipoMovimientoDtoMapper.FromDto(aModificar);
                    _repositorioTipoMovimiento.Update(tipo);
                }
                else
                {
                    throw new TipoMovimientoInvalidoException($"No se pudo modificar porque se perdio la referencia del tipo de movimiento.");
                }
            }
            catch (TipoMovimientoInvalidoException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
