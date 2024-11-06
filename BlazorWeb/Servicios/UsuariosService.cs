using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlazorWeb.Servicios
{
    public class UsuariosService
    {
        private readonly AcademiaDbContextBlazor _context;

        public UsuariosService(AcademiaDbContextBlazor context)
        {
            _context = context;
        }

        public async Task<Usuario?> AuthenticateAsync(string nombreUsuario, string clave)
        {
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(clave))
            {
                Console.WriteLine("El nombre de usuario o la clave están vacíos.");
                return null;
            }

           
            Console.WriteLine($"Intentando autenticar usuario: {nombreUsuario}");

            
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u =>
                u.Nombre_Usuario == nombreUsuario && u.Clave == clave);

            if (usuario == null)
            {
                Console.WriteLine("No se encontró el usuario o las credenciales son incorrectas.");
            }

            return usuario;
        }
    }
}
