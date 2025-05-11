using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Publicacion: IValidable, IComparable<Post> 
    {
        public int Id { get; set; }

        public static int UltimoId { get; set; } = 1;

        public Miembro Autor { get; set; }  

        public DateTime FechaPublicacion {  get; set; }
        
        public string Texto { get; set; } // texto tomamos como contenido de las publicaciones

        public string Titulo {  get; set; }

        public int Like {  get; set; }

        public bool Privado {  get; set; }

        //Siempre protejo la lista, haciéndola privada y sin set
        private List<Reaccion> _reacciones { get; } = new List<Reaccion>();

        public Publicacion()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Publicacion(Miembro autor, DateTime fechaPublicacion, string titulo,string texto, bool privado, List<Reaccion> reacciones)
        {
            Id = UltimoId;
            UltimoId++; 
            Autor = autor;
            FechaPublicacion = fechaPublicacion;
            Titulo = titulo;
            Like = 0;
            Privado = privado;
            _reacciones = reacciones;
            Texto = texto;
        }

        //public int FiltrarTipoReaccion(Tipo tFiltrado)
        //{

        //}

        public void AgregarReaccion(Reaccion r) { // evaluar si es necesaria
            bool usuarioYaReacciono = false;

            foreach (Reaccion reaccionExistente in _reacciones)
            {
                if (reaccionExistente.Autor == r.Autor)
                {
                    usuarioYaReacciono = true;
                    break;
                }
            }
             if(!usuarioYaReacciono)
            { 
                _reacciones.Add(r);
            }
        }
        public virtual void Validar()
        {
            ValidarTexto();
            ValidarTitulo();
        }


        private void ValidarTexto()
        {
            if (string.IsNullOrEmpty(Texto))
            {
                throw new Exception("El texto no debe estar vacio");
            }
        }

        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(Titulo))
            {
                throw new Exception("El titulo no debe estar vacio");
            }
            if(Titulo.Length < 3)
            {
                throw new Exception("El titulo debe tener al menos 3 caracteres");
            }
        }


        public bool TieneReaccionTipo(Tipo tipo)
        {
            // revisar donde va
            return false;
        }

        public abstract int CalcularValorAceptacion(); // es solo firma
        public abstract string GetTipo();




        //criterio de ordenamiento
        public int CompareTo(Post other)
        {
            if(Titulo.CompareTo(other.Titulo) > 0)
            {
                return -1;
            }
            else if(Titulo.CompareTo(other.Titulo) < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
        
