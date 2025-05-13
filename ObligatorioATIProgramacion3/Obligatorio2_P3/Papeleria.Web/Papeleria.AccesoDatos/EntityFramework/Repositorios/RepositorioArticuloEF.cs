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
    public class RepositorioArticuloEF : IRepositorioArticulo
    {
        private PapeleriaContext _context;

        public RepositorioArticuloEF()
        {
            _context = new PapeleriaContext();
        }

        public bool Add(Articulo aAgregar)
        {
            try
            {
                if (aAgregar != null)
                {
                    aAgregar.Validar();
                    //verificar articulo con mismo nombre
                    if (_context.Articulos.Where(articulo => articulo.Nombre == aAgregar.Nombre).FirstOrDefault() != null) throw new ArticuloInvalidoException("Ya existe un articulo con ese nombre");
                    //verificar con mismo codigo
                    if (_context.Articulos.Where(articulo => articulo.CodProd == aAgregar.CodProd).FirstOrDefault() != null) throw new ArticuloInvalidoException("Ya existe un articulo con ese codigo");
                    //agregar articulo
                    _context.Articulos.Add(aAgregar);
                    _context.SaveChanges();
                    return true;
                }
                throw new ArticuloInvalidoException("No se pudo agregar el articulo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Articulo> FindAll()
        {
            try
            {
                return _context.Articulos.OrderBy(articulo => articulo.Nombre);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Articulo FindById(int id)
        {
            try
            {
                if(id > 0)
                {
                    return _context.Articulos.Where(articulo => articulo.Id == id).FirstOrDefault();
                }
                throw new ArticuloInvalidoException("El articulo no existe");
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
                if (id < 0) throw new ArticuloInvalidoException("No se pudo eliminar el articulo");
                //eliminar el articulo del contexto
                _context.Articulos.Remove(new Articulo { Id = id});
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Articulo aActualizar)
        {
            try
            {
                if (aActualizar != null)
                {
                    //validar y encontrar por id
                    aActualizar.Validar();
                    Articulo articulo = FindById(aActualizar.Id);
                    //actualizar las propiedades
                    articulo.Nombre = aActualizar.Nombre;
                    articulo.Descripcion = aActualizar.Descripcion;
                    articulo.CodProd = aActualizar.CodProd;
                    articulo.Precio = aActualizar.Precio;
                    articulo.Stock = aActualizar.Stock;
                    //actualizar el articulo
                    _context.Articulos.Update(articulo);
                    _context.SaveChanges();
                    return true;
                }
                throw new ArticuloInvalidoException("No se pudo actualizar el Articulo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}