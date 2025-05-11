using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Sistema

    {
        private List<Persona> _personas { get; } = new List<Persona>();

        public Sistema()
        {
            PrecargarDatos();
        }

        private void PrecargarDatos()
        {
            Persona p = new Persona("Juan", "juan@juan.com");
            Persona p1 = new Persona("Jorge", "Jorge@Jorge.com");
            Persona p2 = new Persona("Juan", "Ana@Ana.com");
            Persona p3 = new Persona("Maria", "Maria@Maria.com");
            AltaPersona(p);
            AltaPersona(p1);
            AltaPersona(p2);
            AltaPersona(p3);
        }

        public List<Persona> GetPersonas()
        {().
            _personas.Sort();//Va al CompareTo de Persona
            return _personas;
        }

        public void AltaPersona(Persona p)
        {
            try
            {
                p.Validar();
                _personas.Add(p);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
