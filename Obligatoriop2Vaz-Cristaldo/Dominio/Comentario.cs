using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio
{
    public  class Comentario: Publicacion
    {
        public Comentario()
        {
            Id = Id;
            UltimoId++;
        }

        public Comentario(Miembro autor, DateTime fechaPublicacion, string titulo, string texto, bool privado, List<Reaccion> reacciones) : base(autor, fechaPublicacion, titulo, texto, privado, reacciones)
        {
            Id = Id;
            UltimoId++;
        }

        public override void Validar()
        {
            base.Validar();

         
        }

        public override int CalcularValorAceptacion()
        {
            return 1;
        }

        public override string GetTipo()
        {
            return "Comentario";
        }

        
    }
}
