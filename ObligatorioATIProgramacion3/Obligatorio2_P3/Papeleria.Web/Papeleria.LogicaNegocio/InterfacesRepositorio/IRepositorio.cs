using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        bool Add(T aAgregar);
        bool Remove(int id); 
        bool Update(T aActualizar);
    }
}
