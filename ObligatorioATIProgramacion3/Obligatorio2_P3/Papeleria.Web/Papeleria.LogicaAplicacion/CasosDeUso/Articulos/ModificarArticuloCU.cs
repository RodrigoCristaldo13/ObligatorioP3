using Papeleria.LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Articulos
{
    public class ModificarArticuloCU : IModificarArticulo
    {
        private IRepositorioArticulo _repositorioArticulo;
        public ModificarArticuloCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void ModificarArticulo(ArticuloDto aModificar)
        {
            try
            {
                Articulo articulo = ArticuloDtoMapper.FromDto(aModificar);
                _repositorioArticulo.Update(articulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
