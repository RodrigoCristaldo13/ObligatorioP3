using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class TipoMovimiento : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EstadoStock { get; set; } // 1 o -1 si es Aumento o Reduccion de stock

        public void Validar()
        {
            ValidarNombre();
            ValidarEstadoStock();
        }

        private void ValidarNombre()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new TipoMovimientoInvalidoException("Nombre de tipo de movimiento es invalido.");
            }
        }

        private void ValidarEstadoStock()
        {
            if (EstadoStock != 1 && EstadoStock != -1)
            {
                throw new TipoMovimientoInvalidoException("El Tipo de Movimiento debe tener un estado de Stock (1) para Aumento o (-1) para Reduccion del Stock.");
            }
        }
    }
}
