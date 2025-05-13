using Papeleria.LogicaAplicacion.CasosDeUso.Movimientos;
using Papeleria.LogicaAplicacion.InterfacesCU.Movimientos;
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
    public class EliminarTipoMovimientoCU : IEliminarTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorio;
        private IExisteMovimientoDeTipo _existeMovimientoDeTipoCU;
        public EliminarTipoMovimientoCU(
            IRepositorioTipoMovimiento repositorio,
            IExisteMovimientoDeTipo existeMovimientoDeTipo)
        {
            this._repositorio = repositorio;
            this._existeMovimientoDeTipoCU = existeMovimientoDeTipo;
        }
        public void EliminarTipo(int id)
        {
            try
            {
                if (_existeMovimientoDeTipoCU.ExisteMovimientoDeTipo(id))
                {
                    throw new TipoMovimientoInvalidoException($"No se puede eliminar el tipo de movimiento ya que está siendo utilizado en algun Movimiento.");
                }
                _repositorio.Remove(id);
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
