using Entidades;
using proyecto_academia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_academia.Servicios
{
    public class UsuarioService
    {
        public Usuario Authenticate(string nombreUsuario, string clave)
        {
            using var context = new AcademiaDbContext();

            var usuario = context.Usuarios.FirstOrDefault(u => u.Nombre_Usuario == nombreUsuario && u.Clave == clave);
            return usuario;
        }
        public bool Add(Usuario usuario)
        {
            using var context = new AcademiaDbContext();

            if (context.Usuarios.Any(p => p.Nombre_Usuario == usuario.Nombre_Usuario && p.Habilitado == 1))
            {
                return false;
            }

            if (context.Personas.Any(e => e.IdPersona == usuario.IdPersona))
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentException("ID de Persona no válido.");
            }
        }

        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();
            Usuario? usuarioToDelete = context.Usuarios.Find(id);
            if (usuarioToDelete != null)
            {
                context.Usuarios.Remove(usuarioToDelete);
                context.SaveChanges();
            }
        }
        public Usuario? Get(int id)
        {
            using var context = new AcademiaDbContext();
            return context.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var context = new AcademiaDbContext();
            return context.Usuarios.ToList();
        }

        public void Update(Usuario usuario)
        {
            using var context = new AcademiaDbContext();
            
            Usuario? usuarioToUpdate = context.Usuarios.Find(usuario.IdUsuario);

            if (usuarioToUpdate != null)
            {
                usuarioToUpdate.Nombre_Usuario = usuario.Nombre_Usuario;
                usuarioToUpdate.Clave = usuario.Clave;
                usuarioToUpdate.Rol = usuario.Rol;
                context.SaveChanges();
            }
        }
    }
}
