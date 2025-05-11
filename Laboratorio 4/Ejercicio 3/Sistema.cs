using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3
{
    public class Sistema
    {
        private List<Producto> _productos { get; } = new List<Producto>();
        private List<Cliente> _clientes { get; } = new List<Cliente>();

        public void AltaCliente(Cliente c)
        {
            try
            {
                c.EsValido();
                _clientes.Add(c);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void AltaProducto(Producto p)
        {
            try
            {
                p.EsValido();
                _productos.Add(p);
            }
            catch (Exception e) 
            {
                throw;
            }
        }


        public List<Producto> GetProductos() 
        {
            return _productos;
        }

        public List<Cliente> GetClientes()
        {
            return _clientes;

        }

        public void PrecargarDatos()
        {
            Producto p1 = new Producto("AAS", 3, new DateTime(2023, 06, 01), "Aspirina");
            AltaProducto(p1);
            Producto p2 = new Producto("Ibuprofeno", 5, new DateTime(2022, 01, 02), "Actron");
            AltaProducto(p2);

            Cliente c1 = new Cliente("Rodrigo");
            c1.AgregarProducto(p1);
            AltaCliente(c1);
            Cliente c2 = new Cliente("Mariana");
            c2.AgregarProducto(p2);
            AltaCliente(c2);




        }




    }
}
