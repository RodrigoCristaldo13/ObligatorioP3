using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio_Mascota
{
    public class Sistema
    {
        private List<Mascota> _mascotas { get; } = new List<Mascota>();
        private List<Socio> _socios { get; } = new List<Socio>();

        private static Sistema _instancia;

        private Sistema()
        {
            PrecargarDatos();
        }

        public static Sistema Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }

        public void AltaSocio(Socio s)
        {
            try
            {
                s.Validar();
                _socios.Add(s);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void AltaMascota(Mascota m)
        {
            try
            {
                m.Validar();
                _mascotas.Add(m);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Socio> GetSocios()
        {
            return _socios;
        }

        public List<Mascota> GetMascotas()
        {
            return _mascotas;
        }

        public void PrecargarDatos()
        {
            try
            {
                Mascota m1 = new Mascota("Tobi", "Perro", "Callejero", new DateTime(2023, 01, 01));
                AltaMascota(m1);
                Socio s1 = new Socio("Ana", "González", new DateTime(2022, 01, 01));
                AltaSocio(s1);
                Socio s2 = new Socio("Juan", "Perez", new DateTime(2022, 01, 01));
                AltaSocio(s2);
                Mascota m2 = new Mascota("p1", "Perro", "Callejero", new DateTime(2023, 01, 01));
                AltaMascota(m2);
                Mascota m3 = new Mascota("Gatito", "Gato", "Raza gato", new DateTime(2023, 01, 01));
                AltaMascota(m3);
                Mascota m4 = new Mascota("Gatito 2", "Gato", "Raza gato", new DateTime(2023, 01, 01));
                AltaMascota(m4);
            }
            catch (Exception e)
            {

                throw;
            }


        }

        public List<Mascota> GetPerros()
        {
            List<Mascota> listaRet = new List<Mascota>();

            foreach (Mascota m in _mascotas)
            {
                if(m.Tipo == "Perro")
                {
                    listaRet.Add(m);
                }
            }

            return listaRet;
        }



    }
}
