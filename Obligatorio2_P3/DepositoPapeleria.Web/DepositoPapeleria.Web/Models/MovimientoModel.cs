using System.ComponentModel.DataAnnotations.Schema;

namespace DepositoPapeleria.Web.Models
{
    public class MovimientoModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdArticulo { get; set; }
        public ArticuloModel? Articulo { get; set; }
        public int IdTipoMovimiento { get; set; }
        public TipoMovimientoModel? TipoMovimiento { get; set; }
        public string EmailEncargado { get; set; }
        public int Cantidad { get; set; }
    }
}
