using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    public class Gol
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Futbolista Futbolista { get; set; }
        public int Minuto { get; set; }
        public bool Afavor { get; set; }
         public bool TiroPenal { get; set; }

        public Gol() 
        {
            Id = UltimoId;
            UltimoId++;
        }
        public Gol( Futbolista futbolista, int minuto, bool aFavor, bool tiroPenal)
        {
            Id = UltimoId;
            UltimoId++;
            Futbolista = futbolista;
            Minuto = minuto;
            Afavor = aFavor;
            TiroPenal = tiroPenal;
        }

        public override string ToString()
        {
            //hago variable para tipo de gol y de tiro con evaluacion de
            //
            //
            //condiciones

            string tipoGol = Afavor ? "a favor" : "en contra";
            string tipoTiro = TiroPenal ? "de tiro penal" : "de jugada normal";

            return $"Gol de {Futbolista.Nombre} {Futbolista.Apellido} ({tipoGol}) en el minuto {Minuto} {tipoTiro}";
        }
    }
}
