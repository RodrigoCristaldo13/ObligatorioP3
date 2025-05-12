using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.Interfaces;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Movimiento : IValidableConfig
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey(nameof(Articulo))] public int IdArticulo { get; set; }
        public Articulo Articulo { get; set; }
        [ForeignKey(nameof(TipoMovimiento))] public int IdTipoMovimiento { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public string EmailEncargado { get; set; }
        public int Cantidad { get; set; }

        public Movimiento()
        {
        }
        public void Validar(IRepositorioConfiguracion repositorioConfiguracion)
        {
            ValidarArticulo();
            ValidarEncargado();
            ValidarTipoMovimiento();
            ValidarCantidad();
            ValidarCantidadMenorAPrefijada(repositorioConfiguracion);
        }

        private void ValidarTipoMovimiento()
        {
            if (IdTipoMovimiento == 0)
            {
                throw new MovimientoInvalidoException($"El Tipo de movimiento es invalido.");
            }
        }

        private void ValidarEncargado()
        {
            if (String.IsNullOrEmpty(EmailEncargado))
            {
                throw new MovimientoInvalidoException($"El email del Encargado del movimiento es invalido.");
            }
        }

        private void ValidarArticulo()
        {
            if (IdArticulo == 0)
            {
                throw new MovimientoInvalidoException($"El Articulo del movimiento es invalido.");
            }
        }

        private void ValidarCantidadMenorAPrefijada(IRepositorioConfiguracion repositorioConfiguracion)
        {
            double cantidadPrefijada = repositorioConfiguracion.ObtenerValorConfigPorNombre("TopeMaxUnidadesStock");
            if (Cantidad > cantidadPrefijada)
            {
                throw new MovimientoInvalidoException($"La cantidad máxima prefijada para el movimiento es de {cantidadPrefijada} unidades.");
            }
        }

        private void ValidarCantidad()
        {
            if (Cantidad <= 0) throw new MovimientoInvalidoException("El movimiento debe tener un cantidad positiva");
        }

    }
}
