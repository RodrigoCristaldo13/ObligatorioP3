using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Enum;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPedidoEF : IRepositorioPedido
    {
        private PapeleriaContext _context;

        public RepositorioPedidoEF()
        {
            _context = new PapeleriaContext();
        }
        public bool Add(Pedido aAgregar)
        {
            try
            {
                if (aAgregar != null)
                {
                    if (aAgregar.LineasPedido != null && aAgregar.LineasPedido.Count > 0)
                    {
                        aAgregar.Validar(new RepositorioConfiguracionEF()); 
                        //agregamos el pedido
                        _context.Pedidos.Add(aAgregar);
                        _context.SaveChanges();
                        return true;
                    }
                    throw new PedidoInvalidoException("El pedido debe tener al menos una linea");
                }
                throw new PedidoInvalidoException("No fue posible agregar el pedido, se perdió la referencia");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AnularPedido(int id)
        {
            try
            {
                if (id < 0) throw new PedidoInvalidoException("No se pudo anular el pedido");
                Pedido pedido = FindById(id);
                if (pedido != null)
                {
                    //cambiar el estado
                    pedido.Estado = Estado.Anulado;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Pedido> FindAll()
        {
            try
            {
                return _context.Pedidos.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Pedido FindById(int id)
        {
            try
            {
                return _context.Pedidos
                .Where(pedido => pedido.Id == id)
                .Include(pedido => pedido.LineasPedido).ThenInclude(linea => linea.Articulo)
                .Include(pedido => pedido.Cliente)
                .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Cliente> ObtenerClientesMontoTotalMayorA(double montoTotal)
        {
            try
            {
                return _context.Pedidos.Where(pedido => pedido.MontoTotal > montoTotal)
                .Select(pedido => pedido.Cliente)
                .Distinct()
                .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Pedido> ObtenerPedidosAnulados()
        {
            try
            {
                return _context.Pedidos
                .Where(pedido => pedido.Estado == Estado.Anulado)
                .Include(pedido => pedido.LineasPedido).ThenInclude(linea => linea.Articulo)
                .Include(pedido => pedido.Cliente)
                .OrderByDescending(pedido => pedido.FechaPedido)
                .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Pedido> ObtenerPedidosPendientes(DateTime fecha)
        {
            try
            {
                IEnumerable<Pedido> pedidosPendientes = _context.Pedidos
               .Where(pedido => pedido.Estado == Estado.Pendiente)
               .Include(pedido => pedido.LineasPedido).ThenInclude(linea => linea.Articulo)
               .Include(pedido => pedido.Cliente)
               .OrderByDescending(pedido => pedido.FechaPedido) //Ordenamos por fecha de pedido descendiente por preferencia nuestra
               .ToList();

                if (fecha != DateTime.MinValue)
                {
                    pedidosPendientes = pedidosPendientes.Where(pedido => pedido.FechaPedido.Date == fecha.Date).ToList();
                }

                if (pedidosPendientes.Any())
                {
                    return pedidosPendientes;
                }
                else
                {
                    throw new PedidoInvalidoException($"No hay pedidos pendientes con fecha {fecha.ToShortDateString()}");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pedido aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
