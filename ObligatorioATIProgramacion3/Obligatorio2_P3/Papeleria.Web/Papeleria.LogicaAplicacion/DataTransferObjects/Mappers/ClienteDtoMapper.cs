using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.Mappers
{
    public class ClienteDtoMapper
    {
        public static Cliente FromDto(ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto == null) throw new ClienteInvalidoException("El cliente no se pudo agregar");
                return new Cliente
                {
                    Id = clienteDto.Id,
                    Rut = clienteDto.Rut,
                    NombreCompleto = new NombreCompleto(clienteDto.Nombre,clienteDto.Apellido),
                    Direccion = new Direccion(clienteDto.Dir_Calle, clienteDto.Dir_Numero, clienteDto.Dir_Ciudad),
                    RazonSocial = clienteDto.RazonSocial,
                    Distancia = clienteDto.Distancia
                };
            }
            catch (ClienteInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static ClienteDto ToDto(Cliente cliente)
        {
            try
            {
                if (cliente == null) throw new ClienteInvalidoException(nameof(cliente));
                return new ClienteDto
                {
                    Id = cliente.Id,
                    Rut = cliente.Rut,
                    Nombre = cliente.NombreCompleto.Nombre,
                    Apellido = cliente.NombreCompleto.Apellido,
                    Dir_Calle = cliente.Direccion.Calle,
                    Dir_Numero = cliente.Direccion.Numero,
                    Dir_Ciudad = cliente.Direccion.Ciudad,
                    RazonSocial = cliente.RazonSocial,
                    Distancia = cliente.Distancia
                };
            }
            catch (ClienteInvalidoException e)
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
