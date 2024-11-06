using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UI_Escritorio
{
    internal class MateriasApi
    {
        private static HttpClient _materias = new HttpClient();
        static MateriasApi()
        {
            _materias.BaseAddress = new Uri("http://localhost:5183/");
            _materias.DefaultRequestHeaders.Accept.Clear();
            _materias.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<Materia> GetAsync(int id)
        {
            Materia materia = null;
            HttpResponseMessage response = await _materias.GetAsync("materias/" + id);
            if (response.IsSuccessStatusCode)
            {
                materia = await response.Content.ReadAsAsync<Materia>();
            }
            return materia;
        }

        public static async Task<IEnumerable<Materia>> GetAllAsync()
        {
            IEnumerable<Materia> materias = null;
            HttpResponseMessage response = await _materias.GetAsync("materias");
            if (response.IsSuccessStatusCode)
            {
                materias = await response.Content.ReadAsAsync<IEnumerable<Materia>>();
            }
            return materias;
        }

        public async static Task<bool> AddAsync(Materia materia)
        {
            try
            {
                HttpResponseMessage response = await _materias.PostAsJsonAsync("materias", materia);
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
            HttpResponseMessage response = await _materias.DeleteAsync("materias/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Materia materia)
        {
            HttpResponseMessage response = await _materias.PutAsJsonAsync("materias", materia);
            response.EnsureSuccessStatusCode();
        }
    }
}
