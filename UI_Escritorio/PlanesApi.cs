using Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace UI_Escritorio
{
    public class PlanesApi
    {
        private static HttpClient _planes = new HttpClient();
        static PlanesApi()
        {
            _planes.BaseAddress = new Uri("http://localhost:5183/");
            _planes.DefaultRequestHeaders.Accept.Clear();
            _planes.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Plan> GetAsync(int id)
        {
            Plan plan = null;
            HttpResponseMessage response = await _planes.GetAsync("planes/" + id);
            if (response.IsSuccessStatusCode)
            {
                plan = await response.Content.ReadAsAsync<Plan>();
            }
            return plan;
        }

        public static async Task<IEnumerable<Plan>> GetAllAsync()
        {
            IEnumerable<Plan> planes = null;
            HttpResponseMessage response = await _planes.GetAsync("planes");
            if (response.IsSuccessStatusCode)
            {
                planes = await response.Content.ReadAsAsync<IEnumerable<Plan>>();
            }
            return planes;
        }

        public async static Task<bool> AddAsync(Plan plan)
        {
            try
            {
                HttpResponseMessage response = await _planes.PostAsJsonAsync("planes", plan);
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
                throw new Exception("Error al agregar el plan: " + ex.Message);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _planes.DeleteAsync("planes/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Plan plan)
        {
            HttpResponseMessage response = await _planes.PutAsJsonAsync("planes", plan);
            response.EnsureSuccessStatusCode();
        }
    }
}
