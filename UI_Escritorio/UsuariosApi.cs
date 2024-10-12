using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UI_Escritorio
{
    internal class UsuariosApi
    {
        private static HttpClient _usuario = new HttpClient();

        static UsuariosApi()
        {
            _usuario.BaseAddress = new Uri("https://localhost:7111/");
            _usuario.DefaultRequestHeaders.Accept.Clear();
            _usuario.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<Usuario> AuthenticateAsync(string nombreUsuario, string clave)
        {
            Usuario usuario = null;
            var loginUsuario = new Usuario { Nombre_Usuario = nombreUsuario, Clave = clave };
            HttpResponseMessage response = await _usuario.PostAsJsonAsync("usuarios/authenticate", loginUsuario);
            if (response.IsSuccessStatusCode)
            {
                usuario = await response.Content.ReadAsAsync<Usuario>();
            }
            return usuario;
        }
        public static async Task<Usuario> GetAsync(int id)
        {
            Usuario usuario = null;
            HttpResponseMessage response = await _usuario.GetAsync("usuarios/" + id);
            if (response.IsSuccessStatusCode)
            {
                usuario = await response.Content.ReadAsAsync<Usuario>();
            }
            return usuario;
        }

        public static async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            IEnumerable<Usuario> usuarios = null;
            HttpResponseMessage response = await _usuario.GetAsync("usuarios");
            if (response.IsSuccessStatusCode)
            {
                usuarios = await response.Content.ReadAsAsync<IEnumerable<Usuario>>();
            }
            return usuarios;
        }

        public static async Task AddAsync(Usuario usuario)
        {
            HttpResponseMessage response = await _usuario.PostAsJsonAsync("usuarios", usuario);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Usuario usuario)
        {
            HttpResponseMessage response = await _usuario.PutAsJsonAsync("usuarios", usuario);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _usuario.DeleteAsync("usuarios/" + id);
            response.EnsureSuccessStatusCode();
        }
    }
}
