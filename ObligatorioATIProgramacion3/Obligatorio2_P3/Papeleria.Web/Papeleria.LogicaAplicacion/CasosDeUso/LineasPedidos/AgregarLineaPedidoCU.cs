using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.LineasPedidos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.LineasPedidos
{
    public class AgregarLineaPedidoCU : IAgregarLineaPedido
    {
        private IRepositorioLineaPedido _repositorioLineasPedido;

        public AgregarLineaPedidoCU(IRepositorioLineaPedido repositorioLineasPedido)
        {
            _repositorioLineasPedido = repositorioLineasPedido;
        }

        public void AgregarLineaPedido(LineaPedidoDto aAgregar)
        {
            try
            {
                LineaPedido lineaP = LineaPedidoDtoMapper.FromDto(aAgregar);
                this._repositorioLineasPedido.Add(lineaP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
