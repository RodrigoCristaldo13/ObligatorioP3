using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioTipoMovimientoEF : IRepositorioTipoMovimiento
    {
        private PapeleriaContext _context;
        public RepositorioTipoMovimientoEF()
        {
            _context = new PapeleriaContext();
        }
        public bool Add(TipoMovimiento aAgregar)
        {
            try
            {
                if (aAgregar != null)
                {
                    //validamos y agregamos
                    aAgregar.Validar();
                    _context.TiposMovimientos.Add(aAgregar);
                    _context.SaveChanges();
                    return true;
                }
                throw new TipoMovimientoInvalidoException("No se pudo agregar el tipo de movimiento");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TipoMovimiento> FindAll()
        {
            try
            {
                return _context.TiposMovimientos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TipoMovimiento FindById(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _context.TiposMovimientos.Where(tipo => tipo.Id == id).FirstOrDefault();
                }
                throw new TipoMovimientoInvalidoException("El tipo de movimiento no existe");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                if (id < 0) throw new TipoMovimientoInvalidoException("No se pudo encontrar el tipo de movimiento con Id 0");
                _context.TiposMovimientos.Remove(new TipoMovimiento { Id = id });
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(TipoMovimiento aActualizar)
        {
            try
            {
                if (aActualizar != null)
                {
                    aActualizar.Validar();
                    TipoMovimiento tMov = FindById(aActualizar.Id);
                    if (tMov != null)
                    {
                        //actualizar campos
                        tMov.Nombre = aActualizar.Nombre;
                        tMov.EstadoStock = aActualizar.EstadoStock;
                        _context.TiposMovimientos.Update(tMov);
                        _context.SaveChanges();
                        return true;
                    }
                    throw new TipoMovimientoInvalidoException("No existe el Tipo de movimiento");
                }
                throw new TipoMovimientoInvalidoException("No se pudo actualizar el Tipo de movimiento");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
