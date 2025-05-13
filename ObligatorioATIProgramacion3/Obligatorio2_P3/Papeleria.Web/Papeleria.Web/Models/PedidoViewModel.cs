using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;

namespace Papeleria.Web.Models
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntregaPrometida { get; set; }
        public string Estado { get; set; }
        public string ClienteRazonSocial { get; set; }
        public string ClienteContactoNombre { get; set; }
        public double Recargo { get; set; }
        public List<LineaPedidoViewModel> LineasPedido { get; set; }
        public double MontoTotal { get; set; }
    }
}
