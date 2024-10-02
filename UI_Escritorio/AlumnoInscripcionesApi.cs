using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UI_Escritorio
{
    public class AlumnoInscripcionesApi
    {
        private static HttpClient _alumnoInscripciones = new HttpClient();
        static AlumnoInscripcionesApi()
        {
            _alumnoInscripciones.BaseAddress = new Uri("http://localhost:5183/");
            _alumnoInscripciones.DefaultRequestHeaders.Accept.Clear();
            _alumnoInscripciones.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<AlumnoInscripcion> GetAsync(int id)
        {
            AlumnoInscripcion alumnoInscripcion = null;
            HttpResponseMessage response = await _alumnoInscripciones.GetAsync("alumnoinscripciones/" + id);
            if (response.IsSuccessStatusCode)
            {
                alumnoInscripcion = await response.Content.ReadAsAsync<AlumnoInscripcion>();
            }
            return alumnoInscripcion;
        }


        public static async Task<IEnumerable<AlumnoInscripcion>> GetAllAsync()
        {
            IEnumerable<AlumnoInscripcion> alumnoInscripciones = null;
            HttpResponseMessage response = await _alumnoInscripciones.GetAsync("alumnoinscripciones");
            if (response.IsSuccessStatusCode)
            {
                alumnoInscripciones = await response.Content.ReadAsAsync<IEnumerable<AlumnoInscripcion>>();
            }
            return alumnoInscripciones;
        }

        public static async Task AddAsync(AlumnoInscripcion alumnoInscripcion)
        {
            HttpResponseMessage response = await _alumnoInscripciones.PostAsJsonAsync("alumnoinscripciones", alumnoInscripcion);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _alumnoInscripciones.DeleteAsync("alumnoinscripciones/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(AlumnoInscripcion alumnoInscripcion)
        {
            HttpResponseMessage response = await _alumnoInscripciones.PutAsJsonAsync("alumnoinscripciones", alumnoInscripcion);
            response.EnsureSuccessStatusCode();
        }

        public static async Task<IEnumerable<AlumnoInscripcion>> GetByAlumnoIdAsync(int idPersona)
        {
            IEnumerable<AlumnoInscripcion> alumnoInscripciones = null;
            HttpResponseMessage response = await _alumnoInscripciones.GetAsync($"alumnoinscripciones/alumno/{idPersona}");
            if (response.IsSuccessStatusCode)
            {
                alumnoInscripciones = await response.Content.ReadAsAsync<IEnumerable<AlumnoInscripcion>>();
            }
            return alumnoInscripciones;



        }
    }
}
