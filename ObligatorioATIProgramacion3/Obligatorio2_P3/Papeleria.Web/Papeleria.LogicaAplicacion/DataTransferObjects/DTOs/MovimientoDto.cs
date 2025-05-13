using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.DTOs
{
    public class MovimientoDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public int IdArticulo { get; set; }
        public ArticuloDto? Articulo { get; set; }
        public int IdTipoMovimiento { get; set; }
        public TipoMovimientoDto? TipoMovimiento { get; set; }
        public int IdEncargado { get; set; }
        public string EmailEncargado { get; set; }
    }
}
