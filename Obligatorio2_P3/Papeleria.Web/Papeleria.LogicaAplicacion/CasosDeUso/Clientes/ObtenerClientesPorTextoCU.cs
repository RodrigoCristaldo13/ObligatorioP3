using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Clientes
{
    public class ObtenerClientesPorTextoCU : IObtenerClientesPorTexto
    {
        private IRepositorioCliente _repositorioClientes;
        public ObtenerClientesPorTextoCU(IRepositorioCliente repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }

        public IEnumerable<ClienteDto> ObtenerClientes(string texto)
        {
            try
            {
                IEnumerable<Cliente> clientesPorTexto = _repositorioClientes.ObtenerClientesPorTexto(texto);
                return clientesPorTexto.Select(cliente => ClienteDtoMapper.ToDto(cliente)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
