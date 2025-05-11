using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        #region SINGLETON

        private static Sistema _instancia;
        public static Sistema Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();

            }
            return _instancia;
        }

        #endregion

        private List<Publicacion> _publicaciones { get; } = new List<Publicacion>();
        private List<Invitacion> _invitaciones { get; } = new List<Invitacion>();
        private List<Usuario> _usuarios { get; } = new List<Usuario>();
        public Sistema()
        {
            PrecargarDatos();
        }

        #region PRECARGAS

        public void PrecargarDatos()
        {
            try
            {
                PrecargarUsuarios();
                PrecargarPublicaciones();
                PrecargarInvitaciones();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void PrecargarUsuarios()
        {
            try
            {
                Miembro m1 = new Miembro("Rodrigo", "Cristaldo", new DateTime(1995, 02, 13), new List<Miembro>(), false, "rodrigo@gmail.com", "123456");
                Miembro m2 = new Miembro("Angel", "Vaz", new DateTime(1997, 07, 02), new List<Miembro>(), false, "angel@gmail.com", "123456");
                Miembro m3 = new Miembro("Edinson", "Cavani", new DateTime(1987, 02, 14), new List<Miembro>(), false, "edi@gmail.com", "123456");
                Miembro m4 = new Miembro("Diego", "Forlan", new DateTime(1979, 05, 19), new List<Miembro>(), false, "forlan@gmail.com", "123456");
                Miembro m5 = new Miembro("Sergio", "Ramos", new DateTime(1986, 03, 30), new List<Miembro>(), false, "sergio@gmail.com", "123456");
                Miembro m6 = new Miembro("Robert", "Lewandowski", new DateTime(1988, 08, 21), new List<Miembro>(), false, "robert@gmail.com", "123456");
                Miembro m7 = new Miembro("Cristiano", "Ronaldo", new DateTime(1985, 02, 05), new List<Miembro>(), false, "cr7@gmail.com", "123456");
                Miembro m8 = new Miembro("Neymar", "Santos", new DateTime(1992, 02, 05), new List<Miembro>(), false, "neymar@gmail.com", "123456");
                Miembro m9 = new Miembro("Luis", "Suarez", new DateTime(1987, 01, 24), new List<Miembro>(), false, "lucho@gmail.com", "123456");
                Miembro m10 = new Miembro("Lionel", "Messi", new DateTime(1987, 06, 24), new List<Miembro>(), false, "messi@gmail.com", "123456");
                AltaUsuario(m1);
                AltaUsuario(m2);
                AltaUsuario(m3);
                AltaUsuario(m4);
                AltaUsuario(m5);
                AltaUsuario(m6);
                AltaUsuario(m7);
                AltaUsuario(m8);
                AltaUsuario(m9);
                AltaUsuario(m10);

                Administrador admin1 = new Administrador("admin1@gmail.com", "admin321");
                AltaUsuario(admin1);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void PrecargarPublicaciones()
        {
            try
            {
                Post po1 = new Post("balonDeOro.jpg", new List<Comentario>(), false, GetMiembroPorEmail("rodrigo@gmail.com"), new DateTime(2023, 09, 28), "Rivales", "Lionel Messi a un paso de un nuevo balón de oro, se alargará la diferencia con Cristiano Rolando? Ampliaremos", false, new List<Reaccion>());
                Post po2 = new Post("balonDeOro.jpg", new List<Comentario>(), false, GetMiembroPorEmail("messi@gmail.com"), new DateTime(2023, 09, 28), "Rivales", "Lionel Messi a un paso de un nuevo balón de oro, se alargará la diferencia con Cristiano Rolando? Ampliaremos", false, new List<Reaccion>());
                Post po3 = new Post("balonDeOro.jpg", new List<Comentario>(), false, GetMiembroPorEmail("lucho@gmail.com"), new DateTime(2023, 09, 28), "Rivales", "Lionel Messi a un paso de un nuevo balón de oro, se alargará la diferencia con Cristiano Rolando? Ampliaremos", false, new List<Reaccion>());
                Post po4 = new Post("balonDeOro.jpg", new List<Comentario>(), false, GetMiembroPorEmail("angel@gmail.com"), new DateTime(2023, 09, 28), "Rivales", "Lionel Messi a un paso de un nuevo balón de oro, se alargará la diferencia con Cristiano Rolando? Ampliaremos", false, new List<Reaccion>());
                Post po5 = new Post("balonDeOro.jpg", new List<Comentario>(), false, GetMiembroPorEmail("robert@gmail.com"), new DateTime(2023, 09, 28), "Rivales", "Lionel Messi a un paso de un nuevo balón de oro, se alargará la diferencia con Cristiano Rolando? Ampliaremos", false, new List<Reaccion>());
                AltaPublicacion(po1);
                AltaPublicacion(po2);
                AltaPublicacion(po3);
                AltaPublicacion(po4);
                AltaPublicacion(po5);


                Comentario co1 = new Comentario(GetMiembroPorEmail("angel@gmail.com"), new DateTime(), "titulo1", "texto1", false, new List<Reaccion>());
                Comentario co2 = new Comentario(GetMiembroPorEmail("lucho@gmail.com"), new DateTime(), "titulo2", "texto2", false, new List<Reaccion>());
                Comentario co3 = new Comentario(GetMiembroPorEmail("messi@gmail.com"), new DateTime(), "titulo3", "texto3", false, new List<Reaccion>());

                Comentario co4 = new Comentario(GetMiembroPorEmail("cr7@gmail.com"), new DateTime(), "titulo4", "texto4", false, new List<Reaccion>());
                Comentario co5 = new Comentario(GetMiembroPorEmail("sergio@gmail.com"), new DateTime(), "titulo5", "texto5", false, new List<Reaccion>());
                Comentario co6 = new Comentario(GetMiembroPorEmail("edi@gmail.com"), new DateTime(), "titulo6", "texto6", false, new List<Reaccion>());

                Comentario co7 = new Comentario(GetMiembroPorEmail("rodrigo@gmail.com"), new DateTime(), "titulo7", "texto7", false, new List<Reaccion>());
                Comentario co8 = new Comentario(GetMiembroPorEmail("forlan@gmail.com"), new DateTime(), "titulo8", "texto8", false, new List<Reaccion>());
                Comentario co9 = new Comentario(GetMiembroPorEmail("neymar@gmail.com"), new DateTime(), "titulo9", "texto9", false, new List<Reaccion>());

                Comentario co10 = new Comentario(GetMiembroPorEmail("cr7@gmail.com"), new DateTime(), "titulo10", "texto10", false, new List<Reaccion>());
                Comentario co11 = new Comentario(GetMiembroPorEmail("lucho@gmail.com"), new DateTime(), "titulo11", "texto11", false, new List<Reaccion>());
                Comentario co12 = new Comentario(GetMiembroPorEmail("neymar@gmail.com"), new DateTime(), "titulo12", "texto12", false, new List<Reaccion>());

                Comentario co13 = new Comentario(GetMiembroPorEmail("cr7@gmail.com"), new DateTime(), "titulo13", "texto13", false, new List<Reaccion>());
                Comentario co14 = new Comentario(GetMiembroPorEmail("forlan@gmail.com"), new DateTime(), "titulo14", "texto14", false, new List<Reaccion>());
                Comentario co15 = new Comentario(GetMiembroPorEmail("edi@gmail.com"), new DateTime(), "titulo15", "texto15", false, new List<Reaccion>());

                po1.AltaComentario(co1);
                AltaPublicacion(co1);
                po1.AltaComentario(co2);
                AltaPublicacion(co2);
                po1.AltaComentario(co3);
                AltaPublicacion(co3);

                po2.AltaComentario(co4);
                AltaPublicacion(co4);
                po2.AltaComentario(co5);
                AltaPublicacion(co5);
                po2.AltaComentario(co6);
                AltaPublicacion(co6);

                po3.AltaComentario(co7);
                AltaPublicacion(co7);
                po3.AltaComentario(co8);
                AltaPublicacion(co8);
                po3.AltaComentario(co9);
                AltaPublicacion(co9);

                po4.AltaComentario(co10);
                AltaPublicacion(co10);
                po4.AltaComentario(co11);
                AltaPublicacion(co11);
                po4.AltaComentario(co12);
                AltaPublicacion(co12);

                po5.AltaComentario(co13);
                AltaPublicacion(co13);
                po5.AltaComentario(co14);
                AltaPublicacion(co14);
                po5.AltaComentario(co15);
                AltaPublicacion(co15);


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void PrecargarInvitaciones()
        {
            try
            {
                Invitacion i1 = new Invitacion(GetMiembroPorEmail("rodrigo@gmail.com"), GetMiembroPorEmail("angel@gmail.com"), EstadoInvitacion.Aprobada, DateTime.Now);
                Invitacion i2 = new Invitacion(GetMiembroPorEmail("rodrigo@gmail.com"), GetMiembroPorEmail("messi@gmail.com"), EstadoInvitacion.Aprobada, DateTime.Now);
                Invitacion i3 = new Invitacion(GetMiembroPorEmail("rodrigo@gmail.com"), GetMiembroPorEmail("lucho@gmail.com"), EstadoInvitacion.Aprobada, DateTime.Now);
                Invitacion i4 = new Invitacion(GetMiembroPorEmail("messi@gmail.com"), GetMiembroPorEmail("lucho@gmail.com"), EstadoInvitacion.Aprobada, DateTime.Now);
                Invitacion i5 = new Invitacion(GetMiembroPorEmail("angel@gmail.com"), GetMiembroPorEmail("lucho@gmail.com"), EstadoInvitacion.Aprobada, DateTime.Now);
                Invitacion i6 = new Invitacion(GetMiembroPorEmail("angel@gmail.com"), GetMiembroPorEmail("robert@gmail.com"), EstadoInvitacion.Pendiente_Aprobacion, DateTime.Now);
                Invitacion i7 = new Invitacion(GetMiembroPorEmail("robert@gmail.com"), GetMiembroPorEmail("lucho@gmail.com"), EstadoInvitacion.Pendiente_Aprobacion, DateTime.Now);
                Invitacion i8 = new Invitacion(GetMiembroPorEmail("lucho@gmail.com"), GetMiembroPorEmail("neymar@gmail.com"), EstadoInvitacion.Rechazada, DateTime.Now);
                Invitacion i9 = new Invitacion(GetMiembroPorEmail("robert@gmail.com"), GetMiembroPorEmail("neymar@gmail.com"), EstadoInvitacion.Rechazada, DateTime.Now);
                Invitacion i10 = new Invitacion(GetMiembroPorEmail("messi@gmail.com"), GetMiembroPorEmail("robert@gmail.com"), EstadoInvitacion.Pendiente_Aprobacion, DateTime.Now);
                AltaInvitacion(i1);
                AltaInvitacion(i2);
                AltaInvitacion(i3);
                AltaInvitacion(i4);
                AltaInvitacion(i5);
                AltaInvitacion(i6);
                AltaInvitacion(i7);
                AltaInvitacion(i8);
                AltaInvitacion(i9);
                AltaInvitacion(i10);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region ALTAS

        public void AltaUsuario(Usuario u)
        {
            try
            {
                if (u != null)
                {
                    u.Validar();
                    _usuarios.Add(u);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AltaPublicacion(Publicacion p)
        {
            try
            {
                if (p != null)
                {
                    p.Validar();
                    _publicaciones.Add(p);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AltaInvitacion(Invitacion i)
        {
            try
            {
                if (i != null)
                {
                    i.Validar();
                    _invitaciones.Add(i);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion ALTAS

        #region GETS

        public List<Miembro> GetMiembros()
        {
            List<Miembro> miembros = new List<Miembro>();
            foreach (Miembro m in _usuarios)
            {
                if (m != null)
                {
                    miembros.Add(m);
                }
            }
            return miembros;
        }

        public List<Administrador> GetAdministradores()
        {
            List<Administrador> administradores = new List<Administrador>();
            foreach (Administrador a in _usuarios)
            {
                if (a != null)
                {
                    administradores.Add(a);
                }
            }
            return administradores;
        }

        public List<Publicacion> GetPublicaciones()
        {
            return _publicaciones;
        }

        public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();
            foreach (Post p in _publicaciones)
            {
                if (p != null)
                {
                    posts.Add(p);
                }
            }
            return posts;
        }

        public List<Comentario> GetComentarios()
        {
            List<Comentario> comentarios = new List<Comentario>();
            foreach (Comentario c in _publicaciones)
            {
                if (c != null)
                {
                    comentarios.Add(c);
                }
            }
            return comentarios;
        }

        public List<Miembro> GetAmigosMiembro(Miembro m) //EVALUAR  SI ES NECESARIO
        {
            //TODO miembro en sistema
            List<Miembro> amigos = new List<Miembro>();
            amigos = m.GetAmigosMiembro();
            return amigos;
        }

        private Miembro GetMiembroPorEmail(string Email)
        {
            foreach (Miembro usuario in GetMiembros())
            {
                if (usuario.Email.Equals(Email))
                {
                    return usuario;
                }
            }
            return null;
        }

        #endregion

        public void NuevoMiembro(string nombre, string apellido, string fecha, string email, string contrasenia)
        {
            try
            {
                DateTime.TryParse(fecha, out DateTime fechaFormateada);

                Miembro m1 = new Miembro(nombre, apellido, fechaFormateada, new List<Miembro>(), false, email, contrasenia);
                AltaUsuario(m1);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Publicacion> ListarPostsUsuario(string Email)
        {
            List<Publicacion> listaPublicaciones = new List<Publicacion>();
            foreach (Publicacion pub in _publicaciones)
            {
                if (pub.Autor.Email == Email && pub.GetTipo() == "Post")
                {
                    Post postAux = pub as Post;
                    listaPublicaciones.Add(pub);
                }
            }
            return listaPublicaciones;
        }

        public List<Publicacion> ListarComentarioUsuario(string Email)
        {
            List<Publicacion> listaPublicacionesComentarios = new List<Publicacion>();
            foreach (Publicacion pub in _publicaciones)
            {
                if (pub.Autor.Email == Email && pub.GetTipo() == "Comentario")
                {
                    Comentario comentarioAux = pub as Comentario;
                    listaPublicacionesComentarios.Add(pub);
                }
            }
            return listaPublicacionesComentarios;
        }


        public List<Publicacion> ListarPostConComentarioUsuarioSinComentario(string Email)
        {
            List<Publicacion> listaPost = new List<Publicacion>();
            Miembro usuario = GetMiembroPorEmail(Email);

            foreach (Publicacion pubCaso2 in _publicaciones)
            {
                Post postAux = pubCaso2 as Post;
                if (UsuarioTieneComentario(usuario, postAux.GetComentarios()))
                {
                    listaPost.Add(postAux);
                }

                //if (pubCaso2.Autor.Email == Email && pubCaso2.GetTipo() == "Post")
                //{

                //}
            }

            return listaPost;
        }

        public bool UsuarioTieneComentario(Usuario usuario, List<Comentario> lista)
        {
            foreach (Comentario c in lista)
            {
                if (c.Autor == usuario)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Publicacion> ListarPostEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            List<Publicacion> listaPost = new List<Publicacion>();


            foreach (Publicacion p in _publicaciones)

            {
                Post postAux = p as Post;
                if (p.GetTipo() == "Post" && p.FechaPublicacion >= fecha1 && p.FechaPublicacion <= fecha2)
                {
                    listaPost.Add(p);

                }



            }
            listaPost.Sort();
            listaPost.Reverse();
            return listaPost;
        }

        public List<Post> GetPostEnOrden()
        {
            List<Post> posts = GetPosts();
            posts.Sort(); //utiliza compareto
            posts.Reverse(); // revierte la lista
            return posts;

        }

        public List<Miembro> MiembroConMasPublicaciones()
        {
            List<Miembro> listaRet = new List<Miembro>();
            int mayor = -1;
            foreach (Publicacion p in GetPublicaciones())
            {
                int aux = ContarPublicacionesDeMiembro(p.Autor);
                if (aux > mayor)
                {
                    listaRet.Clear();
                    listaRet.Add(p.Autor);
                    mayor = aux;
                }
                else if (aux == mayor)
                {
                    listaRet.Add(p.Autor);
                }
            }

            return listaRet;
        }


        public int ContarPublicacionesDeMiembro(Miembro m)
        {
            int cantidad = 0;

            foreach (Publicacion p in GetPublicaciones())
            {
                if (p.Autor == m)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }



        public int CalcularLargoTextoPost()
        {
            int largo = 0;
            return largo;
        }





    }
}
