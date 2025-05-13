using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.Mappers
{
    public class ArticuloDtoMapper
    {
        public static Articulo FromDto(ArticuloDto articuloDto)
        {
            try
            {
                if (articuloDto == null) throw new ArticuloInvalidoException("El articulo no se pudo agregar");
                return new Articulo
                {
                    Id = articuloDto.Id,
                    Nombre = articuloDto.Nombre,
                    Descripcion = articuloDto.Descripcion,
                    CodProd = articuloDto.CodProd,
                    Precio = articuloDto.Precio,
                    Stock = articuloDto.Stock
                };
            }
            catch (ArticuloInvalidoException e)
            {
                throw e;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static ArticuloDto ToDto(Articulo articulo)
        {
            try
            {
                if (articulo == null) throw new ArticuloInvalidoException(nameof(articulo));
                return new ArticuloDto
                {
                    Id = articulo.Id,
                    Nombre = articulo.Nombre,
                    Descripcion = articulo.Descripcion,
                    CodProd = articulo.CodProd,
                    Precio = articulo.Precio,
                    Stock = articulo.Stock
                };
            }
            catch (ArticuloInvalidoException e)
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
