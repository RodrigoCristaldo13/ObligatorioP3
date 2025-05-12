namespace DepositoPapeleria.Web.Models
{
    public class ResumenModel
    {
        public int Anio { get; set; }
        public List<DetalleResumenModel> Detalles { get; set; }
        public int TotalAnio { get; set; }

        public class DetalleResumenModel
        {
            public string Tipo { get; set; }
            public int Cantidad { get; set; }
        }
    }
}
