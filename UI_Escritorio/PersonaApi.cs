using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;


namespace UI_Escritorio
{
    internal class PersonaApi
    {
        private static HttpClient _persona = new HttpClient();

        static PersonaApi()
        {
            _persona.BaseAddress = new Uri("https://localhost:7111/");
            _persona.DefaultRequestHeaders.Accept.Clear();
            _persona.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Persona> GetAsync(int id)
        {
            Persona persona = null;
            HttpResponseMessage response = await _persona.GetAsync("personas/" + id);
            if (response.IsSuccessStatusCode)
            {
                persona = await response.Content.ReadAsAsync<Persona>();
            }
            return persona;
        }

        public static async Task<IEnumerable<Persona>> GetAllAsync()
        {
            IEnumerable<Persona> personas = null;
            HttpResponseMessage response = await _persona.GetAsync("personas");
            if (response.IsSuccessStatusCode)
            {
                personas = await response.Content.ReadAsAsync<IEnumerable<Persona>>();
            }
            return personas;
        }

        public static async Task<Persona> AddAsync(Persona persona)
        {
            try
            {
                HttpResponseMessage response = await _persona.PostAsJsonAsync("personas", persona);
                response.EnsureSuccessStatusCode(); // Lanza una excepción si el estado no es exitoso
                                                    // Leer el contenido de la respuesta como cadena
                var responseString = await response.Content.ReadAsStringAsync();

                // Verificar si la respuesta está vacía
                if (string.IsNullOrWhiteSpace(responseString))
                {
                    throw new Exception("La respuesta del servidor está vacía.");
                }


                // Deserializar el contenido de la respuesta
                var createdPersona = await response.Content.ReadFromJsonAsync<Persona>();

                if (createdPersona == null)
                {
                    throw new Exception("La respuesta del servidor no contiene un objeto Persona válido.");
                }
                return createdPersona;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al realizar la solicitud HTTP: " + ex.Message);
            }
        }
        public static async Task UpdateAsync(Persona persona)
        {
            HttpResponseMessage response = await _persona.PutAsJsonAsync("personas", persona);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _persona.DeleteAsync("personas/" + id);
            response.EnsureSuccessStatusCode();
        }
    }
}
