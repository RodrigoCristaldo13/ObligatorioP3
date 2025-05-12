using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        private PapeleriaContext _context;

        public RepositorioUsuarioEF()
        {
            _context = new PapeleriaContext();
        }
        public bool Add(Usuario aAgregar)
        {
            try
            {
                if (aAgregar != null)
                {
                    aAgregar.Validar();
                    if (!_context.Usuarios.Any(usuario => usuario.Email == aAgregar.Email))
                    {
                        _context.Usuarios.Add(aAgregar);
                        _context.SaveChanges();
                        return true;
                    }
                    throw new UsuarioInvalidoException("El correo ingresado ya ha sido registrado por otro usuario");
                }
                throw new Exception("No se pudo agregar al usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            try
            {
                return _context.Usuarios;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Usuario FindById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _context.Usuarios.Where(usuario => usuario.Id == id).FirstOrDefault();
                }
                throw new UsuarioInvalidoException("El Id de Usuario es invalido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario ObtenerUsuario(string correo)
        {
            try
            {
                if (correo != null)
                {
                    Usuario usuario = _context.Usuarios.Where(usuario => usuario.Email == correo).FirstOrDefault();
                    if (usuario != null)
                    {
                        return usuario;
                    }
                    throw new UsuarioInvalidoException("No existe usuario con ese correo en nuestra base de datos");
                }
                throw new UsuarioInvalidoException("El correo no debe ser vacio");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Administrador ObtenerAdmin(string correo)
        //{
        //    try
        //    {
        //        if (correo != null)
        //        {
        //            Administrador administrador = _context.Administradores.Where(administrador => administrador.Email == correo).FirstOrDefault();
        //            if (administrador != null)
        //            {
        //                return administrador;
        //            }
        //            throw new UsuarioInvalidoException("No existe usuario con ese correo en nuestra base de datos");
        //        }
        //        throw new UsuarioInvalidoException("El correo no debe ser vacio");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Encargado ObtenerEncargado(string correo)
        //{
        //    try
        //    {
        //        if (correo != null)
        //        {
        //            Encargado encargado = _context.Encargados.Where(encargado => encargado.Email == correo).FirstOrDefault();
        //            if (encargado != null)
        //            {
        //                return encargado;
        //            }
        //            throw new UsuarioInvalidoException("No existe usuario con ese correo en nuestra base de datos");
        //        }
        //        throw new UsuarioInvalidoException("El correo no debe ser vacio");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //POR EL MOMENTO DEVOLVEMOS TODOS LOS ADMMINISTRADORES EN LUGAR DEL FIND ALL
        public IEnumerable<Administrador> ObtenerUsuariosAdministradores()
        {
            try
            {
                return _context.Administradores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Encargado> ObtenerUsuariosEncargados()
        {
            try
            {
                return _context.Encargados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                if (id != 0)
                {
                    //probar en caso de ser Encargado si lo elimina por id
                    _context.Usuarios.Remove(new Administrador { Id = id });
                    _context.SaveChanges();
                    return true;
                }
                throw new UsuarioInvalidoException("El Id de Usuario es invalido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(Usuario aActualizar)
        {
            try
            {
                if (aActualizar != null)
                {
                    aActualizar.Validar();
                    Usuario usuario = FindById(aActualizar.Id);
                    if (usuario != null)
                    {
                        usuario.NombreCompleto = aActualizar.NombreCompleto;
                        usuario.Password = aActualizar.Password;
                        usuario.PasswordEncriptada = aActualizar.PasswordEncriptada;
                        _context.Usuarios.Update(usuario);
                        _context.SaveChanges();
                        return true;
                    }
                    throw new UsuarioInvalidoException("El usuario que intentas modificar no se encuentra en la base de datos");
                }
                throw new UsuarioInvalidoException("No se pudo modificar al usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
