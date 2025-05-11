using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3
{
    public class Cliente
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public DateTime FechaAltaCliente { get; set; }
        private List<Producto> _productos { get; }  = new List<Producto>();

        public Cliente()
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Cliente( string nombre)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            FechaAltaCliente = DateTime.Now;
            
        }

        public void EsValido()
        {
            if(string.IsNullOrEmpty(Nombre))
            {
                throw new Exception(" El nombre no puede ser vacio");
            }
            // entra siempre a la excepcion porque la fecha alta no es exactamente igual a la fecha actual de la validacion.

            //if(FechaAltaCliente != DateTime.Now)
            //{
            //    throw new Exception(" La fecha de alta del cliente debe ser la actual.");
            //}
        }

        public void AgregarProducto(Producto p)
        {
            try
            {
                if(p !=null)
                {
                    p.EsValido();
                    _productos.Add(p);
                }
                
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }


        public List<Producto> GetProductos()
        {
            return _productos;
        }  





    }
}
