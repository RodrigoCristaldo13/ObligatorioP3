using Papeleria.LogicaAplicacion.InterfacesCU.Configuraciones;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Configuraciones
{
    public class ObtenerValorConfigPorNombreCU : IObtenerValorConfigPorNombre
    {
        private IRepositorioConfiguracion _repositorioConfiguracion;
        public ObtenerValorConfigPorNombreCU(IRepositorioConfiguracion repositorioConfiguracion)
        {
            _repositorioConfiguracion = repositorioConfiguracion;
        }

        public double ObtenerValorPorNombre(string nombre)
        {
            try
            {
                return _repositorioConfiguracion.ObtenerValorConfigPorNombre(nombre);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
