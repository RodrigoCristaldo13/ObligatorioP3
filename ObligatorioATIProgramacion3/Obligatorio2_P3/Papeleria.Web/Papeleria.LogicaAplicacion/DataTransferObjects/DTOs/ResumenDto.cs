using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.DTOs
{
    public class ResumenDto
    {
        public int Anio { get; set; }
        public List<DetalleResumenDto> Detalles { get; set; }
        public int TotalAnio { get; set; }

        public class DetalleResumenDto
        {
            public string Tipo { get; set; }
            public int Cantidad { get; set; }
        }
    }
}
