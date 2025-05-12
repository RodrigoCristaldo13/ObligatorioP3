using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Articulos
{
    public class AgregarArticuloCU : IAgregarArticulo
    {
        private IRepositorioArticulo _repositorioArticulos;
        public AgregarArticuloCU(IRepositorioArticulo repositorioArticulos)
        {
            this._repositorioArticulos = repositorioArticulos;
        }

        public void AgregarArticulo(ArticuloDto aAgregar)
        {
            try
            {
                //mapear el dto a Articulo
                Articulo nuevo = ArticuloDtoMapper.FromDto(aAgregar);
                this._repositorioArticulos.Add(nuevo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
