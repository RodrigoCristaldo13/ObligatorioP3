using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedidos
{
    public class AgregarPedidoCU : IAgregarPedido
    {
        private IRepositorioPedido _repositorioPedidos;

        public AgregarPedidoCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedidos = repositorioPedido;
        }

        public void AgregarPedido(PedidoDto aAgregar) //Recomendacion usar un bool para identificar si es Express o Comun
        {
            try
            {
                TimeSpan tiempoTranscurrido = aAgregar.FechaEntregaPrometida - DateTime.Now;
                // Si el tiempo transcurrido es menor 7 días, lo creamos como Express y
                // le hacemos las validaciones de plazo estipulado en la propia clase
                if (tiempoTranscurrido.TotalDays < 7) 
                {
                    Pedido pedidoExpress = PedidoDtoMapper.DtoAExpress(aAgregar);
                    _repositorioPedidos.Add(pedidoExpress);
                }
                else // Si el tiempo transcurrido es mayor a 7 dias (una semana), se considera un pedido común
                {
                    Pedido pedidoComun = PedidoDtoMapper.DtoAComun(aAgregar);
                    _repositorioPedidos.Add(pedidoComun);
                }
            }
            catch (PedidoInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
