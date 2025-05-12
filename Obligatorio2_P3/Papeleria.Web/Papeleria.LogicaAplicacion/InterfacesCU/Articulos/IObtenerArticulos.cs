using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Articulos
{
    public interface IObtenerArticulos
    {
        public IEnumerable<ArticuloDto> ObtenerArticulos();
    }
}
