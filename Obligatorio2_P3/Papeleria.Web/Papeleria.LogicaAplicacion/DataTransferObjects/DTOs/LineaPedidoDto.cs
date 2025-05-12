using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.DTOs
{
    public class LineaPedidoDto
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public ArticuloDto Articulo { get; set; }
        public int CantidadUnidadesPedidas { get; set; }
        public double PrecioUnitarioVigente { get; set; }
    }
}
