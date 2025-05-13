using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.Movimientos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Movimientos
{
    public class AgregarMovimientoCU : IAgregarMovimiento
    {
        private IRepositorioMovimiento _repositorio;
        public AgregarMovimientoCU(IRepositorioMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }
        public void AgregarMovimiento(MovimientoDto aAgregar)
        {
            try
            {
                //convertir DTO a Movimiento y agregar
                Movimiento nuevo  = MovimientoDtoMapper.FromDto(aAgregar);
                this._repositorio.Add(nuevo);
            }
            catch(MovimientoInvalidoException ex) {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
