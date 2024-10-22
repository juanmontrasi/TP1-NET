using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using Entidades;
using System.Collections;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BlazorWeb
{
    public class DocenteCursosApi
    {
        private static HttpClient _docenteCursos = new HttpClient();

        static DocenteCursosApi()
        {
            _docenteCursos.BaseAddress = new Uri("http://localhost:5183/");
            _docenteCursos.DefaultRequestHeaders.Accept.Clear();
            _docenteCursos.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<DocenteCurso> GetAsync(int id)
        {
            DocenteCurso docenteCurso = null;
            HttpResponseMessage response = await _docenteCursos.GetAsync("docentecursos/" + id);
            if (response.IsSuccessStatusCode)
            {
                docenteCurso = await response.Content.ReadFromJsonAsync<DocenteCurso>();
            }
            return docenteCurso;

        }

        public static async Task<IEnumerable<DocenteCurso>> GetAllAsync()
        {
            IEnumerable<DocenteCurso> docenteCursos = null;
            HttpResponseMessage response = await _docenteCursos.GetAsync("docentecursos");
            if (response.IsSuccessStatusCode)
            {
                docenteCursos = await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCurso>>();
            }
            return docenteCursos;
        }

        public static async Task<bool> AddAsync(DocenteCurso docenteCurso)
        {
            
            HttpResponseMessage response = await _docenteCursos.PostAsJsonAsync("docentecursos", docenteCurso);

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                return false; 
            }

            response.EnsureSuccessStatusCode(); 
            return true; 
        }



        public static async Task<bool> UpdateAsync(DocenteCurso docenteCurso)
        {
            HttpResponseMessage response = await _docenteCursos.PutAsJsonAsync("docentecursos", docenteCurso);
            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                return false;
            }
            response.EnsureSuccessStatusCode();
            return true;
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _docenteCursos.DeleteAsync("docentecursos/" + id);
            response.EnsureSuccessStatusCode();
        }


        public static async Task<IEnumerable<DocenteCurso>> GetDocenteCursoByIdAsync(int id)
        {
            IEnumerable<DocenteCurso> docenteCursos = null;
            HttpResponseMessage response = await _docenteCursos.GetAsync("docentecursos/docente" + id);
            if (response.IsSuccessStatusCode)
            {
                docenteCursos = await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCurso>>();
            }
            return docenteCursos;
        }

        public static async Task<IEnumerable<Persona>> GetDocentesAsync()
        {
            IEnumerable<Persona> docentes = null;
            HttpResponseMessage response = await _docenteCursos.GetAsync("docentes");
            if (response.IsSuccessStatusCode)
            {
                docentes = await response.Content.ReadFromJsonAsync<IEnumerable<Persona>>();
            }
            return docentes;
        }

        public static async Task<IEnumerable<Curso>> GetCursosAsync()
        {
            IEnumerable<Curso> cursos = null;
            HttpResponseMessage response = await _docenteCursos.GetAsync("cursos");
            if (response.IsSuccessStatusCode)
            {
                cursos = await response.Content.ReadFromJsonAsync<IEnumerable<Curso>>();
            }
            return cursos;
        }

    }
}
