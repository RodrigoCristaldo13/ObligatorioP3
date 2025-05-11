using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMotor
{
    public class Motor
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;

        public int Chasis { get; set; }

        public int Cilindros { get; set; } 


        public Motor()
        {


        }

        public Motor(int chasis, int cilindros)
        {
            Id = UltimoId;
            Chasis = chasis;
            Cilindros = cilindros;
                
        }

    }
}
