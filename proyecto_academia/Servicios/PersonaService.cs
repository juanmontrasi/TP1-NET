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
        public Persona Add(Persona persona)
        {
            using var context = new AcademiaDbContext();
            context.Add(persona);
            context.SaveChanges();
            return persona;
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

    }
}
