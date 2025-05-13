using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    [Index(nameof(CodProd), IsUnique = true)]
    public class Articulo : IValidable
    {
        public int Id { get; set; }

        [StringLength(200, ErrorMessage = "El nombre debe tener como máximo 200 caracteres.", MinimumLength = 10)]
        [MinLength(10, ErrorMessage = "El nombre debe tener al menos 10 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción debe tener como máximo 200 caracteres.", MinimumLength = 5)]
        [MinLength(5, ErrorMessage = "La descripción debe tener al menos 5 caracteres.")]
        public string Descripcion { get; set; }

        [StringLength(13, ErrorMessage = "El código de barras debe tener como máximo 13 caracteres.", MinimumLength = 13)]
        [MinLength(13, ErrorMessage = "El código de barras debe tener exactamente 13 caracteres.")]
        public string CodProd { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public Articulo()
        {

        }

        public void Validar()
        {
            ValidarNombre();
            ValidarCodigo();
            ValidarPrecio();
            ValidarStock();
            ValidarDescripcion();
        }

        private void ValidarStock()
        {
            try
            {
                if (Stock <= 0) throw new ArticuloInvalidoException("El articulo debe tener un stock positivo");
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

        private void ValidarDescripcion()
        {
            try
            {
                if (String.IsNullOrEmpty(Descripcion)) throw new ArticuloInvalidoException("La descripcion no puede ser vacia");
                if (Descripcion.Length < 5 || Descripcion.Length > 200) throw new ArticuloInvalidoException("La descripcion debe tener entre 5 y 200 caracteres");
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

        private void ValidarPrecio()
        {
            try
            {
                if (Precio <= 0) throw new ArticuloInvalidoException("El articulo debe tener un precio valido");
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

        private void ValidarCodigo()
        {
            try
            {
                if (String.IsNullOrEmpty(CodProd)) throw new ArticuloInvalidoException("El codigo no puede ser vacio");
                if (CodProd.Length != 13) throw new ArticuloInvalidoException("El codigo del articulo debe ser de 13 digitos");
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

        private void ValidarNombre()
        {
            try
            {
                if (String.IsNullOrEmpty(Nombre)) throw new ArticuloInvalidoException("El nombre no puede ser vacio y debe ser valido");
                if (Nombre.Length < 10 || Nombre.Length > 200) throw new ArticuloInvalidoException("El nombre debe tener entre 10 y 200 caracteres");
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