using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Articulos
{
    public class ObtenerArticuloPorIdCU : IObtenerArticuloPorId
    {
        private IRepositorioArticulo _repositorioArticulos;

        public ObtenerArticuloPorIdCU(IRepositorioArticulo repositorioArticulos)
        {
            _repositorioArticulos = repositorioArticulos;
        }

        public ArticuloDto ObtenerArticulo(int id)
        {
            try
            {
                //obtener por id y convertir a DTO
                Articulo articulo = _repositorioArticulos.FindById(id);
                ArticuloDto articuloDto = ArticuloDtoMapper.ToDto(articulo);
                return articuloDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
