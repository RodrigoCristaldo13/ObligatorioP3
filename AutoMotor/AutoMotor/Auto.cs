using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMotor
{
    public class Auto
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;

        public Motor Motor { get; set; }

           

        public Auto() 
        { 
            Id = UltimoId;
            UltimoId++;
        }


        public Auto(Motor motor) 
        {
            Id = UltimoId;
            UltimoId++;
            Motor = motor;
        
        
        }


        public override string ToString()
        {
            return "El id del auto es: " + Id ;
        }




    }
}
