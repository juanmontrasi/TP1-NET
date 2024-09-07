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
namespace UI_Escritorio
{
    public class AlumnoApi
    {
        private static HttpClient alumno = new HttpClient();
        static AlumnoApi()
        {
            alumno.BaseAddress = new Uri("http://localhost:5183/");
            alumno.DefaultRequestHeaders.Accept.Clear();
            alumno.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }


        public static async Task<IEnumerable<Usuario>> GetAllAsync()
        {   
            IEnumerable<Usuario> personas = null;
            HttpResponseMessage response = await alumno.GetAsync("Usuario");
            if (response.IsSuccessStatusCode)
            {
                personas = await response.Content.ReadAsAsync<IEnumerable<Usuario>>();
            }
            return personas;
        }
    }  
}
