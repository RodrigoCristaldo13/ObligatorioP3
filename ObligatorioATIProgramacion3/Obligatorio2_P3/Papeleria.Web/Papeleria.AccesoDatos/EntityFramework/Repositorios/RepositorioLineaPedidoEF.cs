using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    //public class RepositorioLineaPedidoEF : IRepositorioLineaPedido
    //{
    //    private PapeleriaContext _context;

    //    public RepositorioLineaPedidoEF()
    //    {
    //        _context = new PapeleriaContext();
    //    }

    //    public bool Add(LineaPedido aAgregar)
    //    {
    //        try
    //        {
    //            if (aAgregar != null)
    //            {
    //                //aAgregar.Validar();
    //                _context.LineasPedido.Add(aAgregar);
    //                _context.SaveChanges();
    //                return true;
    //            }
    //            return false;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //    }

    //    public IEnumerable<LineaPedido> FindAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public LineaPedido FindById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Remove(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Update(LineaPedido aActualizar)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
