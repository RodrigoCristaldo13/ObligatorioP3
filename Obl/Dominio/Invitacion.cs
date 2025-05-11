using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Invitacion : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;

        public Miembro MiembroSolicitante { get; set; }
        public Miembro MiembroSolicitado { get; set; }
        public EstadoInvitacion Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }

        public Invitacion()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Invitacion(Miembro miembroSolicitante, Miembro miembroSolicitado, EstadoInvitacion estado, DateTime fechaSolicitud)
        {
            Id = UltimoId;
            UltimoId++;
            MiembroSolicitante = miembroSolicitante;
            MiembroSolicitado = miembroSolicitado;
            Estado = estado;
            FechaSolicitud = fechaSolicitud;

        }

        //posibilidad de separar validar miembro bloqueado por solicitante y solicitado o dejarlos en un metodo
        private void ValidarMiembroSolicitanteBloqueado()
        {
            if (MiembroSolicitante.Bloqueado)
            {
                throw new Exception("Miembro solicitante esta bloqueado por el administrador, se limitan funciones");
            }

        }

        private void ValidarMiembroSolicitadoBloqueado()
        {
            if (MiembroSolicitado.Bloqueado)
            {
                throw new Exception("Miembro solicitado bloqueado por el administrador, se limitan funciones");
            }
        }


        //private void ValidarMiembroSolicitado()
        //{

        //}
        //private void ValidarMiembroSolicitante()
        //{

        //}


        public void Validar()
        {
            ValidarMiembroSolicitanteBloqueado();
            ValidarMiembroSolicitadoBloqueado();

            //ValidarMiembroSolicitado();
            //ValidarMiembroSolicitante();
        }




        public override string ToString()
        {
            return "aahjs";
        }
    }
}
