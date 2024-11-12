using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorWebAcademia.Servicios;
using Entidades;

namespace BlazorWebAcademia
{
    public class UsuariosApi
    {
        private static readonly HttpClient _usuarioClient = new HttpClient();

        static UsuariosApi()
        {
            _usuarioClient.BaseAddress = new Uri("https://localhost:7111/");
            _usuarioClient.DefaultRequestHeaders.Accept.Clear();
            _usuarioClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Usuario> AuthenticateAsync(string nombreUsuario, string clave)
        {
            Usuario usuario = null;
            var loginUsuario = new Usuario { Nombre_Usuario = nombreUsuario, Clave = clave };


            HttpResponseMessage response = await _usuarioClient.PostAsJsonAsync("usuarios/authenticate", loginUsuario);
            if (response.IsSuccessStatusCode)
            {
                usuario = await response.Content.ReadFromJsonAsync<Usuario>();
            }

            return usuario;
        }
    }
}
