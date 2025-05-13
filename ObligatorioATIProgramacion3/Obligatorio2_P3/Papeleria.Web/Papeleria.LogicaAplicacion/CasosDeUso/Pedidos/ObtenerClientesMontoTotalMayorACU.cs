using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedidos
{
    public class ObtenerClientesMontoTotalMayorACU : IObtenerClientesMontoTotalMayorA
    {
        private IRepositorioPedido _repositorioPedidos;

        public ObtenerClientesMontoTotalMayorACU(IRepositorioPedido repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        public IEnumerable<ClienteDto> ObtenerClientes(double totalDePedido)
        {
            try
            {
                IEnumerable<Cliente> clientesPorMontoTotal = _repositorioPedidos.ObtenerClientesMontoTotalMayorA(totalDePedido);
                return clientesPorMontoTotal.Select(cliente => ClienteDtoMapper.ToDto(cliente)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
