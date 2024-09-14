using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UI_Escritorio
{
    public class CursosApi
    {
        private static HttpClient _cursos = new HttpClient();
        static CursosApi()
        {
            _cursos.BaseAddress = new Uri("http://localhost:5183/");
            _cursos.DefaultRequestHeaders.Accept.Clear();
            _cursos.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<Curso> GetAsync(int id)
        {
            Curso curso = null;
            HttpResponseMessage response = await _cursos.GetAsync("cursos/" + id);
            if (response.IsSuccessStatusCode)
            {
                curso = await response.Content.ReadAsAsync<Curso>();
            }
            return curso;
        }

        public static async Task<IEnumerable<Curso>> GetAllAsync()
        {
            IEnumerable<Curso> cursos = null;
            HttpResponseMessage response = await _cursos.GetAsync("cursos");
            if (response.IsSuccessStatusCode)
            {
                cursos = await response.Content.ReadAsAsync<IEnumerable<Curso>>();
            }
            return cursos;
        }

        public async static Task AddAsync(Curso curso)
        {
            HttpResponseMessage response = await _cursos.PostAsJsonAsync("cursos", curso);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _cursos.DeleteAsync("cursos/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Curso curso)
        {
            HttpResponseMessage response = await _cursos.PutAsJsonAsync("cursos", curso);
            response.EnsureSuccessStatusCode();
        }
    }
}
