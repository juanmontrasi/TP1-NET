﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
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

        public async static Task AddAsync(Plan plan)
        {
            HttpResponseMessage response = await _planes.PostAsJsonAsync("planes", plan);
            response.EnsureSuccessStatusCode();
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