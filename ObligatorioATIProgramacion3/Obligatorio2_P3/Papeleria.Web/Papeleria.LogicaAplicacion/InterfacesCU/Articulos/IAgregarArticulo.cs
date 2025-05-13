using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Articulos
{
    public interface IAgregarArticulo
    {
        public void AgregarArticulo(ArticuloDto aAgregar);
    }
}
