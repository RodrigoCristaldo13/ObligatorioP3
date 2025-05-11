using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Miembro:Usuario, IValidable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        private List<Miembro> ListaAmigos { get; } = new List<Miembro>();
        public bool Bloqueado { get; set; }


        public Miembro()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Miembro(string nombre, string apellido, DateTime fechaNacimiento, List<Miembro> listaAmigos, bool bloqueado,string email, string contrasenia): base(email,contrasenia)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            ListaAmigos = listaAmigos;
            Bloqueado = bloqueado;
        }

        public void AgregarAmigo(Miembro miembroAmigo)
        {
            if(!ListaAmigos.Contains(miembroAmigo))
            {
     
                ListaAmigos.Add(miembroAmigo);
            }
            else
            {
                throw new Exception($"{Nombre} ya es amigo de {miembroAmigo.Nombre}");
            }

        }

        public List<Miembro> GetAmigosMiembro() //EVALUAR  SI ES 
        {
           return ListaAmigos;
        }

        public void AceptarSolicitud(Invitacion i)
        {
            if(i.Estado == EstadoInvitacion.Pendiente_Aprobacion)
            {
                i.Estado = EstadoInvitacion.Aprobada;
                AgregarAmigo(i.MiembroSolicitante);
                
                
            }
        }

        public void RechazarSolicitud(Invitacion i)
        {
            if(i.Estado == EstadoInvitacion.Pendiente_Aprobacion)
            {
                i.Estado = EstadoInvitacion.Rechazada;
            }
        }

        private void ValidarNombreApellido()
        {
            if(string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacio");
            }
            if(string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("El apellido no puede estar vacio");
            }
        }

        public override void Validar()
        {
            base.Validar();
            ValidarNombreApellido();
        }

        public override string ToString()
        {
            return $"{Nombre } + {Apellido} + {FechaNacimiento}+ {Email}";
        }
    }
}
