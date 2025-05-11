using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5
{
    public class Duenio
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public int NumeroDeSocio { get; set; }
        public string Email { get; set; }
        public DateTime FechaUltimoPago { get; set; }
        public static double PrecioMensualidadc { get; set; } = 50.0;  //podria ser privado
        public static double MontoMinimoPago { get; set; } = 60.0;

        public Servicio Servicio { get; set; }

        public Duenio() 
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Duenio(string nombre, string documento, int numeroDeSocio, string email, DateTime fechaUltimoPago, Servicio servicio)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Documento = documento;
            NumeroDeSocio = numeroDeSocio;
            Email = email;
            FechaUltimoPago = fechaUltimoPago;
            Servicio = servicio;
        }

        public void RealizarPago(double montoPago)
        {
            if (montoPago >= MontoMinimoPago)
            {
                FechaUltimoPago = DateTime.Now;
            }
        }


    }
}
