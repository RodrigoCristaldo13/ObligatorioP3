using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoComun : Pedido
    {
        public PedidoComun() { }

        public override void Validar(IRepositorioConfiguracion repositorioConfiguracion)
        {
            base.Validar(repositorioConfiguracion);
            if (!ValidarFechaPrometida())
            {
                throw new PedidoInvalidoException("La fecha prometida para el pedido comun debe ser 7 dias posterior a la fecha actual");
            }
        }

        private bool ValidarFechaPrometida()
        {
            TimeSpan diferenciaDias = FechaEntregaPrometida - FechaPedido;

            if (diferenciaDias.TotalDays >= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void CalcularRecargo()
        {
            // Recargo del 5% si la distancia a la dirección de entrega supera los 100 km
            if (Cliente.Distancia > 100)
            {
                Recargo = 0.05;
            }
            Cliente = null; // Vaciamos el cliente antes de agregar el pedido a la BD para evitar conflicto KEY
        }
    }
}
