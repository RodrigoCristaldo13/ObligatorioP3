using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Clientes
{
    public class ObtenerClientePorIdCU : IObtenerClientePorId
    {
        private IRepositorioCliente _repositorioClientes;

        public ObtenerClientePorIdCU(IRepositorioCliente repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }

        public ClienteDto ObtenerCliente(int id)
        {
            try
            {
                if(id == 0) { throw new ClienteInvalidoException("El cliente no existe en nuestra base de datos"); }
                Cliente cliente = _repositorioClientes.FindById(id);
                ClienteDto clienteDto = ClienteDtoMapper.ToDto(cliente);
                return clienteDto;
            }
            catch (ClienteInvalidoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
