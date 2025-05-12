using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioConfiguracionEF : IRepositorioConfiguracion
    {
        private PapeleriaContext _context;
        public RepositorioConfiguracionEF()
        {
            this._context = new PapeleriaContext();
        }
        public bool Add(Configuracion aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Configuracion> FindAll()
        {
            throw new NotImplementedException();
        }

        public Configuracion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public double ObtenerValorConfigPorNombre(string nombre)
        {
            try
            {
                return _context.Configuraciones.Where(config => config.Nombre == nombre).FirstOrDefault().Valor;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Configuracion aActualizar)
        {
            //Configuracion config = _context.Configuraciones.Where(config => config.Nombre == aActualizar.Nombre).FirstOrDefault();
            //config.Valor = aActualizar.Valor;
            //return true;
            throw new NotImplementedException();
        }
    }
}
