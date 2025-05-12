using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.LineasPedidos
{
    public interface IAgregarLineaPedido
    {
        public void AgregarLineaPedido(LineaPedidoDto aAgregar);
    }
}
