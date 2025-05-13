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
    public class ObtenerClientesCU : IObtenerClientes
    {
        private IRepositorioCliente _repositorioClientes;

        public ObtenerClientesCU(IRepositorioCliente repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }

        public IEnumerable<ClienteDto> ObtenerClientes()
        {
            try
            {
                IEnumerable<Cliente> clientes = _repositorioClientes.FindAll();
                return clientes.Select(cliente => ClienteDtoMapper.ToDto(cliente)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
