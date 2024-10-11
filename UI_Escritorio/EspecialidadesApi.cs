using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace UI_Escritorio
{
    public class EspecialidadesApi
    {
        private static HttpClient _especialidad = new HttpClient();
        static EspecialidadesApi()
        {
            _especialidad.BaseAddress = new Uri("https://localhost:7111/");
            _especialidad.DefaultRequestHeaders.Accept.Clear();
            _especialidad.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Especialidad> GetAsync(int id)
        {
            Especialidad especialidad = null;
            HttpResponseMessage response = await _especialidad.GetAsync("especialidades/" + id);
            if (response.IsSuccessStatusCode)
            {
                especialidad = await response.Content.ReadAsAsync<Especialidad>();
            }
            return especialidad;
        }

        public static async Task<IEnumerable<Especialidad>> GetAllAsync()
        {
            IEnumerable<Especialidad> especialidades = null;
            HttpResponseMessage response = await _especialidad.GetAsync("especialidades");
            if (response.IsSuccessStatusCode)
            {
                especialidades = await response.Content.ReadAsAsync<IEnumerable<Especialidad>>();
            }
            return especialidades;
        }

        public static async Task<bool> AddAsync(Especialidad especialidad)
        {
            try
            {
                HttpResponseMessage response = await _especialidad.PostAsJsonAsync("especialidades", especialidad);
                response.EnsureSuccessStatusCode(); 
                return true; 
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    return false; 
                }
                throw new Exception("Error al realizar la solicitud HTTP: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la especialidad: " + ex.Message);
            }
        }
        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _especialidad.DeleteAsync("especialidades/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Especialidad especialidad)
        {
            HttpResponseMessage response = await _especialidad.PutAsJsonAsync("especialidades", especialidad);
            response.EnsureSuccessStatusCode();
        }
    }
}
