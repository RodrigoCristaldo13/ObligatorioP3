using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Dominio
{
    public class Sistema
    {
        private List<Socio> _socios = new List<Socio>();
        private List<Contenido> _contenidos = new List<Contenido>();
        private List<Compra> _compras = new List<Compra>();

        #region Singleton
        private static Sistema _instancia;
        public static Sistema Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }
        #endregion
        private Sistema()
        {
            PrecargarContenidos();
            PrecargarSocios();
            PrecargarCompras();
        }

        #region Precargas
        private void PrecargarSocios()
        {
            AltaSocio(new Socio("Andrés", "Ureta", "1111111"));

        }
        private void PrecargarContenidos()
        {
            Pelicula p1 = new Pelicula(false, 150, "Harry Potter", 2000, "Ficción");
            Pelicula p2 = new Pelicula(true, 150, "Rápidos y Furiosos 10", 2023, "Acción");
            Pelicula p3 = new Pelicula(true, 100, "Thor", 2022, "Acción");
            AltaContenido(p1);
            AltaContenido(p2);
            AltaContenido(p3);
            Serie s1 = new Serie(200, "Breaking Bad", 2010, "Suspenso");
            Serie s2 = new Serie(400, "Friends", 2000, "Comedia");
            Serie s3 = new Serie(80, "La Casa de Papel", 2018, "Drama");
            AltaContenido(s1);
            AltaContenido(s2);
            AltaContenido(s3);
        }
        private void PrecargarCompras()
        {
            AltaCompra(new Compra(GetSocioPorCedula("1111111"), GetContenidoPorTitulo("Harry Potter")));
            AltaCompra(new Compra(GetSocioPorCedula("1111111"), GetContenidoPorTitulo("Rápidos y Furiosos 10")));
            AltaCompra(new Compra(GetSocioPorCedula("1111111"), GetContenidoPorTitulo("Thor")));
            AltaCompra(new Compra(GetSocioPorCedula("1111111"), GetContenidoPorTitulo("Breaking Bad")));
            AltaCompra(new Compra(GetSocioPorCedula("1111111"), GetContenidoPorTitulo("Friends")));
        }
        #endregion

        public List<Socio> GetSocios()
        {
            return _socios;
        }
        public List<Contenido> GetContenidos()
        {
            return _contenidos;
        }
        public List<Compra> GetCompras()
        {
            return _compras;
        }
        public List<Pelicula> GetPeliculas()
        {
            List<Pelicula> listaRetorno = new List<Pelicula>();

            foreach (Contenido c in _contenidos)
            {
                if (c.GetTipo() == "Pelicula")
                {
                    Pelicula pelAux = c as Pelicula;
                    listaRetorno.Add(pelAux);
                }
            }
            return listaRetorno;
        }
        public List<Serie> GetSeries()
        {
            List<Serie> listaRetorno = new List<Serie>();

            foreach (Contenido c in _contenidos)
            {
                if (c.GetTipo() == "Serie")
                {
                    Serie serieAux = c as Serie;
                    listaRetorno.Add(serieAux);
                }
            }
            return listaRetorno;
        }
        public void AltaSocio(Socio s)
        {
            if (!_socios.Contains(s))
            {
                try
                {
                    s.Validar();
                    _socios.Add(s);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                throw new Exception("El socio ya existe en la lista");
            }
        }

        public List<Compra> GetComprasPorMonto(double monto)
        {
            List<Compra> listaRetorno = new List<Compra>();
            foreach (Compra compra in _compras)
            {
                if (compra.Precio > monto)
                {
                    listaRetorno.Add(compra);
                }
            }
            return listaRetorno;
        }

        public void AltaContenido(Contenido c)
        {
            if (!_contenidos.Contains(c))
            {
                try
                {
                    c.Validar();
                    _contenidos.Add(c);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                throw new Exception("El contenido ya existe en la lista");
            }
        }

        public void AltaCompra(Compra c)
        {
            try
            {
                c.Validar();
                _compras.Add(c);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Contenido GetContenidoPorTitulo(string titulo)
        {
            foreach (Contenido c in _contenidos)
            {
                if (c.Titulo == titulo)
                {
                    return c;
                }
            }
            return null;
        }

        private Socio GetSocioPorCedula(string cedula)
        {
            foreach (Socio socio in _socios)
            {
                if (socio.Cedula.Equals(cedula))
                {
                    return socio;
                }
            }
            return null;
        }



    }
}
