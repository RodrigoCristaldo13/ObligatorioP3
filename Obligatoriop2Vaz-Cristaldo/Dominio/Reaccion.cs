using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reaccion
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;

        public Tipo Tipo { get; set; }

        public Miembro Autor {  get; set; }


        public Reaccion()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Reaccion(Tipo tipo, Miembro autor)
        {
            Id = UltimoId;
            UltimoId++;
            Tipo = tipo;
            Autor = autor;
        }



        public override string ToString()
        {
            return "alal";
        }
    }
}
