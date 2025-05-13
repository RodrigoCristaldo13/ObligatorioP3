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
    public class ExisteMovimientoDeTipoCU : IExisteMovimientoDeTipo
    {
        private IRepositorioMovimiento _repositorio;
        public ExisteMovimientoDeTipoCU(IRepositorioMovimiento repositorio)
        {
            _repositorio = repositorio;
        }

        public bool ExisteMovimientoDeTipo(int tipoId)
        {
            try
            {
                //verificar que exista
                if (tipoId != 0)
                {
                    return _repositorio.ExisteMovimientoDeTipo(tipoId);
                }
                else
                {
                    return false;
                }
            }
            catch (MovimientoInvalidoException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            };
        }
    }
}
