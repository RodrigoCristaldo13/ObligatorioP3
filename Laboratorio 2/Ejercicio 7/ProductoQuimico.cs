using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio_7
{
    public class ProductoQuimico
    {

        private int _Id { get;  set; }
        private string _Nombre { get; set; }
        private string _Activo { get; set; }
        private double _Concentracion { get; set; }
        private DateTime _FechaFabricacion { get; set; }
        
        //ctor

        public ProductoQuimico(int id, string nombre, string activo, double concentracion, DateTime fechaFabricacion)
        {
            _Id = id;
            _Nombre = nombre;
            _Activo = activo;
            _Concentracion = concentracion;
            _FechaFabricacion = fechaFabricacion;
        }

        //metodo
        public DateTime CalcularFechaVencimiento()
        {
            return _FechaFabricacion.AddYears(2).AddMonths(6); // esto son 2 anios y medio
        }


        public override string ToString()
        {
            return $"Producto {_Id}: {_Nombre}, Activo: {_Activo}, Concentración: {_Concentracion}, Fabricación: {_FechaFabricacion.ToShortDateString()}";
        }




    }
}
