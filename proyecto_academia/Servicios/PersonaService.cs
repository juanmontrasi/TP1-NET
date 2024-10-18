using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using proyecto_academia.Context;

namespace proyecto_academia.Servicios
{
    public class PersonaService
    {
        public bool Add(Persona persona)
        {
            using var context = new AcademiaDbContext();

            
            if (context.Personas.Any(p => p.Nombre == persona.Nombre && p.Apellido == persona.Apellido && p.FechaNacimiento == persona.FechaNacimiento))
            {
                return false; 
            }

            context.Personas.Add(persona);
            context.SaveChanges();
            return true; 
        }


        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();
            Persona? personaToDelete = context.Personas.Find(id);
            if (personaToDelete != null)
            {
                context.Personas.Remove(personaToDelete);
                context.SaveChanges();
            }
        }
        public Persona? Get(int id)
        {
            using var context = new AcademiaDbContext();
            return context.Personas.Find(id);
        }

        public IEnumerable<Persona> GetAll()
        {
            using var context = new AcademiaDbContext();
            return context.Personas.ToList();
        }

        public void Update(Persona persona)
        {
            using var context = new AcademiaDbContext();
            Persona? personaToUpdate = context.Personas.Find(persona.IdPersona);

            if (personaToUpdate != null)
            {
                personaToUpdate.Nombre = persona.Nombre;
                personaToUpdate.Apellido = persona.Apellido;
                personaToUpdate.Direccion = persona.Direccion;
                personaToUpdate.FechaNacimiento = persona.FechaNacimiento;
                personaToUpdate.Mail = persona.Mail;
                context.SaveChanges();
            }
        }

        public Persona? GetPersonaCreated(string Nombre, string Apellido, string FechaNacimiento)
        {
            using var context = new AcademiaDbContext();
            return context.Personas.FirstOrDefault(p => p.Nombre == Nombre && p.Apellido == Apellido && p.FechaNacimiento == FechaNacimiento);
        }
    }
}
