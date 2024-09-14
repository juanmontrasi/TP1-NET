using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UI_Escritorio
{
    public class ComisionesApi
    {
        private static HttpClient _comisiones = new HttpClient();
        static ComisionesApi()
        {
            _comisiones.BaseAddress = new Uri("http://localhost:5183/");
            _comisiones.DefaultRequestHeaders.Accept.Clear();
            _comisiones.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<Comision> GetAsync(int id)
        {
            Comision comision = null;
            HttpResponseMessage response = await _comisiones.GetAsync("comisiones/" + id);
            if (response.IsSuccessStatusCode)
            {
                comision = await response.Content.ReadAsAsync<Comision>();
            }
            return comision;
        }

        public static async Task<IEnumerable<Comision>> GetAllAsync()
        {
            IEnumerable<Comision> comisiones = null;
            HttpResponseMessage response = await _comisiones.GetAsync("comisiones");
            if (response.IsSuccessStatusCode)
            {
                comisiones = await response.Content.ReadAsAsync<IEnumerable<Comision>>();
            }
            return comisiones;
        }

        public async static Task AddAsync(Comision comision)
        {
            HttpResponseMessage response = await _comisiones.PostAsJsonAsync("comisiones", comision);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _comisiones.DeleteAsync("comisiones/" + id);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(Comision comision)
        {
            HttpResponseMessage response = await _comisiones.PutAsJsonAsync("comisiones", comision);
            response.EnsureSuccessStatusCode();
        }
    }
}
