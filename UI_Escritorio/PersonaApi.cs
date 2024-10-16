﻿using Entidades;
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

        public async static Task<bool> AddAsync(Persona persona)
        {
            try
            {
                HttpResponseMessage response = await _persona.PostAsJsonAsync("personas", persona);

                if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    return false; 
                }

                response.EnsureSuccessStatusCode(); 
                return true; 
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al realizar la solicitud HTTP: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la persona: " + ex.Message);
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

        public static async Task<Persona> GetPersonaCreated(string Nombre, string Apellido, string FechaNacimiento)
        {
            Persona persona = null;
            HttpResponseMessage response = await _persona.GetAsync("personas/GetPersonaCreated?Nombre=" + Nombre + "&Apellido=" + Apellido + "&FechaNacimiento=" + FechaNacimiento);
            if (response.IsSuccessStatusCode)
            {
                persona = await response.Content.ReadAsAsync<Persona>();
            }
            return persona;
        }
    }
}
