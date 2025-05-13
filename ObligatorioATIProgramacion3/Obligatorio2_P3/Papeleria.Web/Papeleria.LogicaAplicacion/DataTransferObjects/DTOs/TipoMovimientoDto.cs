using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.DTOs
{
    public class TipoMovimientoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EstadoStock { get; set; } // 1 o -1 si es Aumento o Reduccion de stock
    }
}
