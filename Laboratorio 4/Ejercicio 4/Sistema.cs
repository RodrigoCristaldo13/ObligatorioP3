using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_4
{
    public class Sistema
    {
        private List<Socio> _socios { get; } = new List<Socio>();
        private List<Actividad> _actividades { get; } = new List<Actividad>();
        private List<Deporte> _deportes { get; } = new List<Deporte>();

        public void AltaSocio(Socio s)
        {
            try
            {
                s.Validar();
                _socios.Add(s);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void AltaActividad(Actividad a)
        {
            try 
            { 
                a.ValidarActividad();
                _actividades.Add(a);
            }
            catch (Exception e) 
            { 
                throw; 
            }
        
        }
        
        public void AltaDeporte(Deporte d)
        {
            try
            {
                d.ValidarDeporte();
                _deportes.Add(d);
            }
            catch (Exception e) 
            {
            throw;
            }
        }

        public List<Deporte> GetDeportes()
        {
            return _deportes;
        }

        public List<Actividad> GetActividades()
        { 
            return _actividades; 
        }

        public List<Socio> GetSocios()
        {
            return _socios;
        }

        public void PrecargarDatos()
        {
           



            Socio s1= new Socio("Socio1", "socio1@hotmail.com");
            AltaSocio(s1);
            Socio s2 = new Socio("Socio2", "socio2@hotmail.com");
            AltaSocio(s2);

            Deporte d1 = new Deporte("Futbol", true);
            AltaDeporte(d1);
            Deporte d2 = new Deporte("PingPong", false);
            AltaDeporte(d2);

            Actividad a1 = new Actividad(d1, new DateTime(2023, 02, 01));
            a1.AgregarSocio(s1);
            AltaActividad(a1);
            
            
            Actividad a2 = new Actividad(d2, new DateTime(2022, 06, 15));
            a2.AgregarSocio(s2);
            AltaActividad(a2);
            
           

        }

        
    }
}




            
            
  