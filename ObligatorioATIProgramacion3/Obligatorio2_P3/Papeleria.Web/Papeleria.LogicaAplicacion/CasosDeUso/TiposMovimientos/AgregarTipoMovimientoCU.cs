using Papeleria.LogicaAplicacion.DataTransferObjects.DTOs;
using Papeleria.LogicaAplicacion.DataTransferObjects.Mappers;
using Papeleria.LogicaAplicacion.InterfacesCU.TiposMovimientos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TiposMovimientos
{
    public class AgregarTipoMovimientoCU : IAgregarTipoMovimiento
    {
        private IRepositorioTipoMovimiento _repositorio;
        public AgregarTipoMovimientoCU(IRepositorioTipoMovimiento repositorio)
        {
            this._repositorio = repositorio;
        }
        public void AgregarTipo(TipoMovimientoDto aAgregar)
        {
            try
            {
                TipoMovimiento nuevo = TipoMovimientoDtoMapper.FromDto(aAgregar);
                this._repositorio.Add(nuevo);
            }
            catch (TipoMovimientoInvalidoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
