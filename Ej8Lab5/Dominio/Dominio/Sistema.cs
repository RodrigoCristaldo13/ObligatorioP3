using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {

        #region SINGLETON
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

        #endregion

        #region Listas
        private List<Sala> _salas = new List<Sala>();
        private List<Presentacion> _presentaciones = new List<Presentacion>();
        private List<Obra> _obras = new List<Obra>();
        private List<Actor> _actores = new List<Actor>();
        private List<Teatro> _teatros = new List<Teatro>();



        #endregion

        #region getters y setters

        public List<Actor> GetActores()
        {
            return _actores;
        }
        public List<Sala> GetSala()
        {
            return _salas;
        }
        public List<Presentacion> GetPresentaciones()
        {
            return _presentaciones;
        }
        public List<Obra> GetObras()
        {
            return _obras;
        }
        public List<Teatro> GetTeatros()
        {
            return _teatros;
        }
        #endregion

        #region Altas
        public void AltaSala(Sala x)
        {

            try
            {
                x.Validar();
                _salas.Add(x);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void AltaPresentacion(Presentacion x)
        {

            try
            {
                x.Validar();
                _presentaciones.Add(x);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void AltaObra(Obra x)
        {

            try
            {
                x.Validar();
                _obras.Add(x);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void AltaActor(Actor x)
        {

            try
            {
                x.Validar();
                _actores.Add(x);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Altateatro(Teatro x)
        {

            try
            {
                x.Validar();
                _teatros.Add(x);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        #endregion


        #region RF
        public List<Obra> GetObrasMayor500(string nombre)
        {
            List<Obra> listaObra = new List<Obra>();

            
            foreach(Obra o in _obras)
            {
                if(GetActores().)
            }
        }

        #endregion

        #region Precargas
        private void PrecargarDatos()
        {

            Actor a1 = new Actor("Juan", "Perez", "jperez@email.com", new DateTime(1981, 05, 08));
            Actor a2 = new Actor("Ana", "Fernandez", "afernanedz@email.com", new DateTime(1994, 07, 02));
            AltaActor(a1);
            AltaActor(a2);


            Teatro t1 = new Teatro("Circular");
            Teatro t2 = new Teatro("El galpón");
            Altateatro(t1);
            Altateatro(t2);

            Sala sala1 = new Sala("Sala circular", 350, t1);
            Sala sala2 = new Sala("Campodonico", 600, t2);
            AltaSala(sala1);
            AltaSala(sala2);

            Obra o1 = new Importada("Esperando la carroza", 25000);
            Obra o2 = new Propia("La vida de un programador");
            AltaObra(o1);
            AltaObra(o2);


            Presentacion p1 = new Presentacion(new DateTime(2023, 04, 23), 250, sala2, o2, false);
            p1.CantidadEntradas = 550;
            Presentacion p2 = new Presentacion(new DateTime(2023, 04, 27), 650, sala1, o1, true);

            AltaPresentacion(p1);
            AltaPresentacion(p2);
        }
        #endregion
    }
}
