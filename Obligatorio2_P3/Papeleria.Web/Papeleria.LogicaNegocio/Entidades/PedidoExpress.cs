using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoExpress : Pedido
    {
        public double PlazoEstipulado { get; set; } // Verificar si es necesaria la property
        public PedidoExpress()
        {
        }
        public override void Validar(IRepositorioConfiguracion repositorioConfiguracion)
        {
            try
            {
                base.Validar(repositorioConfiguracion);
                ValidarPlazoEstipulado(repositorioConfiguracion); // Una validacion a nivel ed BBDD, Quizas este no sea el mejor lugar
                ValidarFechaPrometida();
            }
            catch (PedidoInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void ValidarPlazoEstipulado(IRepositorioConfiguracion repositorioConfiguracion)
        {
            PlazoEstipulado = repositorioConfiguracion.ObtenerValorConfigPorNombre("PlazoDiasEntregaExpress");
            if (PlazoEstipulado < 0 || PlazoEstipulado > 5)
            {
                throw new PedidoInvalidoException("El plazo estipulado para entrega del pedido express debe estar comprendido entre 0 y 5 días.");
            }
        }

        private bool ValidarFechaPrometida()
        {
            TimeSpan diferenciaDias = FechaEntregaPrometida - FechaPedido;

            if (diferenciaDias.TotalDays <= PlazoEstipulado/* && diferenciaDias.TotalDays <= 5*/)
            {
                return true;
            }
            else
            {
                throw new PedidoInvalidoException($"La fecha de entrega del pedido Express puede ser de hasta {PlazoEstipulado} dias posteriores a la fecha actual. Sugerencia: pedido Comun se entrega a partir de una semana");
            }
        }

        protected override void CalcularRecargo()
        {
            TimeSpan diferenciaDias = FechaEntregaPrometida - FechaPedido;
            int dias = diferenciaDias.Days;

            // Recargo del 10% para los pedidos express
            Recargo = 0.10;

            // Recargo adicional del 5% si la entrega es en el mismo día
            if (dias == 0)
            {
                Recargo += 0.05;
            }
        }

    }
}
