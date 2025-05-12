using System.ComponentModel.DataAnnotations;

namespace DepositoPapeleria.Web.Models
{
    public class ArticuloModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CodProd { get; set; }
        public double Precio { get; set; }
    }
}