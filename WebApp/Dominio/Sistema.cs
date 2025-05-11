using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {

        private List<Cliente> _clientes = new List<Cliente>();
        private static Sistema _instancia;

        private Sistema()
        {
            PrecargarDatos();
        }

        private void PrecargarDatos()
        {
            Cliente c1 = new Cliente("Andrés", "andres@mail.com");
            Cliente c2 = new Cliente("Ana", "ana@mail.com");
            AltaCliente(c1);
            AltaCliente(c2);
        }

        public static Sistema GetInstancia()
        {
            if(_instancia == null )
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }

        public List<Cliente> GetClientes()
        {
            return _clientes;
        }

        public void AltaCliente (Cliente cliente)
        {
            _clientes.Add(cliente); //necesito hacer validaciones
        }

        }




    }
}
