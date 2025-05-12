using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Articulos
{
    public class ObtenerArticulosCU : IObtenerArticulos
    {
        private IRepositorioArticulo _repositorioArticulos;

        public ObtenerArticulosCU(IRepositorioArticulo repositorioArticulos)
        {
            _repositorioArticulos = repositorioArticulos;
        }

        public IEnumerable<ArticuloDto> ObtenerArticulos()
        {
            try
            {
                //obtener todos los articulos y convertir lista a lista DTO
                IEnumerable<Articulo> articulos = _repositorioArticulos.FindAll();
                return articulos.Select(articulo => ArticuloDtoMapper.ToDto(articulo)).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
