using Microsoft.EntityFrameworkCore;
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
    public class RepositorioMovimientoEF : IRepositorioMovimiento
    {
        private PapeleriaContext _context;
        public RepositorioMovimientoEF()
        {
            _context = new PapeleriaContext();
        }
        public bool Add(Movimiento aAgregar)
        {
            try
            {
                if (aAgregar != null)
                {
                    aAgregar.Validar(new RepositorioConfiguracionEF());
                    //agregar el movimiento
                    _context.Movimientos.Add(aAgregar);
                    _context.SaveChanges();
                    return true;
                }
                throw new MovimientoInvalidoException("No se pudo agregar el movimiento");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Articulo> ArticulosConMovimientosEntreFechas(string fechaDesde, string fechaHasta, int numPag, double cantidad)
        {
            try
            {
                if (DateTime.TryParse(fechaDesde, out DateTime fechaDesdeFormateada) && DateTime.TryParse(fechaHasta, out DateTime fechaHastaFormateada))
                {
                    // Incluimos todo el dia de la fecha final
                    fechaHastaFormateada = fechaHastaFormateada.AddDays(1).AddTicks(-1);

                    return _context.Movimientos.Include(m => m.Articulo)
                                                .Where(m => m.Fecha >= fechaDesdeFormateada && m.Fecha <= fechaHastaFormateada)
                                                .Select(m => m.Articulo)
                                                .Distinct()
                                                .Skip((numPag - 1) * (int)cantidad)
                                                .Take((int)cantidad)
                                                .ToList();
                }
                throw new ArticuloInvalidoException("Fecha Invalida.");
            }
            catch (ArticuloInvalidoException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Movimiento> FindAll()
        {
            try
            {
                return _context.Movimientos.Include(m => m.Articulo)
                                           .Include(m => m.TipoMovimiento)
                                           .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Movimiento FindById(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _context.Movimientos.Where(m => m.Id == id)
                                                .Include(m => m.Articulo)
                                                .Include(m => m.TipoMovimiento)
                                                .FirstOrDefault();
                }
                throw new MovimientoInvalidoException("El movimiento no existe");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Movimiento> MovimientosArticuloPorTipo(int idArticulo, string tipo, int numPag, double cantidad)
        {
            try
            {
                return _context.Movimientos
                    .Include(m => m.Articulo)
                    .Include(m => m.TipoMovimiento)
                    .Where(m => m.Articulo.Id.Equals(idArticulo) && m.TipoMovimiento.Nombre == tipo)
                    .OrderByDescending(m => m.Fecha)
                        .ThenBy(m => m.Cantidad)
                    .Skip((numPag - 1) * (int)cantidad)
                    .Take((int)cantidad)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExisteMovimientoDeTipo(int tipoId)
        {
            try
            {
                return _context.Movimientos.Any(m => m.IdTipoMovimiento == tipoId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Movimiento aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
