using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Configuracion
    {
        [Key]
        public string Nombre { get; set; }
        public double Valor { get; set; }
    }
}
