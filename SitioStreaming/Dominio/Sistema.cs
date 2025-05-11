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
            PrecargarSocios();
            PrecargarContenidos();
            PrecargarCompras();
        }

        #region Precargas
        private void PrecargarSocios()
        {
            //TODO
        }

        private void PrecargarContenidos()
        {
            //TODO
        }
        private void PrecargarCompras()
        {
            //TODO
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

        public void AltaSocio(Socio s)
        {
            //TODO
        }

        public void AltaContenido(Contenido c)
        {
            //TODO
        }

        public void AltaCompra(Compra c)
        {
            //TODO
        }

        






    }
}
