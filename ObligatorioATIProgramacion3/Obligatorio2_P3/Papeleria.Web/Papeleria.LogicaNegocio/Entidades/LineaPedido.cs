using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class LineaPedido : IValidable
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Articulo))] public int IdArticulo { get; set; }
        public Articulo Articulo { get; set; }
        public int CantidadUnidadesPedidas { get; set; }
        public double PrecioUnitarioVigente { get; set; }
        public LineaPedido() { }

        public void Validar()
        {
            ValidarArticulo();
        }

        private void ValidarArticulo()
        {
            if (Articulo == null)
            {
                throw new ArticuloInvalidoException("El articulo para el pedido no puede ser nulo");
            }
        }
    }
}
