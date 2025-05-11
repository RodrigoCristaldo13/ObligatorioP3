using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Post : Publicacion, IValidable, IComparable<Post>
    {
        public string Imagen { get; set; }
        private List<Comentario> _comentarios { get; } = new List<Comentario>();
        public bool Censurado { get; set; }


        public Post(string v)
        {
            Id = Id;
            UltimoId++;
        }


        public Post(string imagen, List<Comentario> comentarios, bool censurado, Miembro autor, DateTime fechaPublicacion, string titulo, string texto, bool privado, List<Reaccion> reacciones) : base(autor, fechaPublicacion, titulo, texto, privado, reacciones)
        {

            //propiedades especificas del post
            Id = UltimoId;
            UltimoId++;
            Imagen = imagen;
            Censurado = censurado;
            _comentarios = comentarios;

            
        }


        private void ValidarExtension()
        {
            if (string.IsNullOrEmpty(Imagen))
            {
                throw new Exception("La imagen del post no puede estar vacia");
            }
            // tenemos la opcion de hacerlo insensible a mayusculas y minusculas con ".OrdinalIgnoreCase"
            if (!Imagen.EndsWith(".jpg", StringComparison.Ordinal) || !Imagen.EndsWith(".png", StringComparison.Ordinal))
            {
                throw new Exception("La extension debe ser (.jpg) o (.png)");
            }
        }

        public override void Validar()
        {
            base.Validar();
            ValidarExtension();
        }

        public override int CalcularValorAceptacion()
        {
            return 1;
        }


        public void MostrarPostPrivado(List<Miembro> listaAmigo)
        {
            if (Privado && !listaAmigo.Contains(Autor))
            {
                throw new Exception("No tiene acceso al post provado");
            }
        }

        public void AltaComentario(Comentario c)
        {
            try
            {
                if (c != null)
                {
                    c.Validar();
                    _comentarios.Add(c);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string GetTipo()
        {
            return "Post";
        }

        public List<Comentario> GetComentarios()
        {
            return _comentarios;
        }

        public override string ToString()
        {
            return $"Id : {Id}, Fecha de Publicacion :  {FechaPublicacion}, Titulo : {Titulo}, Texto: {Texto}";
        }


    }


}
