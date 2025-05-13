using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Interfaces
{
    public interface IValidableConfig
    {
        public void Validar(IRepositorioConfiguracion repositorioConfiguracion);
    }
}
