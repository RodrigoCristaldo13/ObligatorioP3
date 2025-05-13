using Papeleria.LogicaNegocio.Enum;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.Interfaces;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public abstract class Pedido : IValidableConfig
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntregaPrometida { get; set; }
        [ForeignKey(nameof(Cliente))] public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public List<LineaPedido> LineasPedido { get; set; } = new List<LineaPedido>();
        public double Recargo { get; set; } = 0;
        public Estado Estado { get; set; } = Estado.Pendiente;
        public double MontoTotal { get; set; } = 0;

        public Pedido()
        {
        }
        public virtual void Validar(IRepositorioConfiguracion repositorioConfiguracion)
        {
            ValidarCliente();
            ValidarFechas();
            ValidarRecargo();
            CalcularRecargo();
            CalcularMontoTotal(repositorioConfiguracion);
        }

        private void ValidarCliente()
        {
            if (IdCliente == 0) 
            {
                throw new PedidoInvalidoException("El cliente seleccionado no existe");
            }
        }

        private void ValidarFechas()
        {
            TimeSpan diferenciaFechas = FechaEntregaPrometida - FechaPedido;

            if (diferenciaFechas.TotalSeconds <= 0)
            {
                throw new PedidoInvalidoException("La fecha de entrega debe ser posterior a la fecha actual");
            }
        }

        private void ValidarRecargo()
        {
            if (Recargo < 0)
            {
                throw new PedidoInvalidoException("El recargo no puede ser negativo");
            }
        }
        protected abstract void CalcularRecargo();

        private void CalcularMontoTotal(IRepositorioConfiguracion repositorioConfiguracion)
        {
            try
            {
                MontoTotal = LineasPedido.Sum(linea => linea.CantidadUnidadesPedidas * linea.PrecioUnitarioVigente);
                double IVA = (repositorioConfiguracion.ObtenerValorConfigPorNombre("IVA") / 100) + 1;
                MontoTotal *= (Recargo + 1);
                MontoTotal *= IVA;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}