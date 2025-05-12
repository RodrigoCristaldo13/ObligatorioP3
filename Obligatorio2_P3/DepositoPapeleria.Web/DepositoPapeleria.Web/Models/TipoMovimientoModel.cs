namespace DepositoPapeleria.Web.Models
{
    public class TipoMovimientoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string EstadoStock { get; set; }

        public override string ToString()
        {
            if (EstadoStock == "1")
            {
                EstadoStock = "Aumento de stock";
            }
            else
            {
                EstadoStock = "Reducción de stock";
            }
            return $"Movimientos de Tipo {Id}-{Nombre} que corresponden a {EstadoStock} del articulo";
        }
    }
}