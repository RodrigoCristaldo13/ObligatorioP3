using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.DTOs
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        [Required(ErrorMessage = "Ingrese una fecha de entrega")]
        public DateTime FechaEntregaPrometida { get; set; }
        public int IdCliente { get; set; }
        public ClienteDto Cliente { get; set; }
        public List<LineaPedidoDto> LineasPedido { get; set; } = new List<LineaPedidoDto>();
        public double Recargo { get; set; } = 0;
        public double MontoTotal { get; set; }
        public string Estado { get; set; }
    }
}
