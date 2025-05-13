using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioClienteEF : IRepositorioCliente
    {
        private PapeleriaContext _context;

        public RepositorioClienteEF()
        {
            _context = new PapeleriaContext();
        }
        public bool Add(Cliente aAgregar)
        {
            try
            {
                //agregar cliente
                _context.Clientes.Add(aAgregar);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Cliente> FindAll()
        {
            try
            {
                //retornar todos los clientes
                return _context.Clientes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cliente FindById(int id)
        {
            try
            {
                //retorno un cliente
                return _context.Clientes.Where(cliente => cliente.Id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IEnumerable<Cliente> ObtenerClientesPorTexto(string texto)
        {
            try
            {
                return _context.Clientes.Where(cliente => cliente.NombreCompleto.Nombre.Contains(texto) || cliente.NombreCompleto.Apellido.Contains(texto));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //MIGRAMOS A PEDIDOS
        //public IEnumerable<Cliente> ObtenerClientesTotalPedidosMayor(double montoTotal)
        //{
        //    IEnumerable<Pedido> losPedidos = _context.Pedidos;
        //    List<Cliente> clientesFiltrados = _context.Clientes
        //                        .Where(c => losPedidos
        //                            .Any(p => p.IdCliente == c.Id &&
        //                                 p.LineasPedido.Sum(lp => lp.PrecioUnitarioVigente * lp.CantidadUnidadesPedidas) > montoTotal))
        //                        .ToList();

        //    return clientesFiltrados;
        //}

        //IEnumerable<Cliente> losClientes = _context.Pedidos.Where(pedido => pedido.MontoTotal > montoTotal).Select(pedido => pedido.Cliente).Distinct().ToList();

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
