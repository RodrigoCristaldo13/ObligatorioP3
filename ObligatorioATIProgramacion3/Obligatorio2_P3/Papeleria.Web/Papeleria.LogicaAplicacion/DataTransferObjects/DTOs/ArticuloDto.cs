using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DataTransferObjects.DTOs
{
    public class ArticuloDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de articulo")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "Ingrese una descripcion del articulo")]
        public string Descripcion { get; set; }
        
        [Required(ErrorMessage = "Ingrese el codigo de producto del articulo")]
        //[StringLength(13, MinimumLength = 13, ErrorMessage = "El código de barras debe tener exactamente 13 dígitos.")]
        public string CodProd { get; set; }
        
        [Required(ErrorMessage = "Ingrese el precio del articulo")]
        public double Precio { get; set; }
        
        [Required(ErrorMessage = "Ingrese la cantidad de unidades en stock del articulo")]
        public int Stock { get; set; }
    }
}
