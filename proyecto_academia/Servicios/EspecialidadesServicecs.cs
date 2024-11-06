using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using proyecto_academia.Context;

namespace proyecto_academia.Servicios
{
    public class EspecialidadesServicecs
    {
        public bool Add(Especialidad especialidad)
        {
            using var context = new AcademiaDbContext();

            if (context.Especialidades.Any(e => e.Nombre_Especialidad == especialidad.Nombre_Especialidad))
            {
                return false; 
            }

            context.Especialidades.Add(especialidad);
            context.SaveChanges();
            return true; 
        }



        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();

            Especialidad? especialidadToDelete = context.Especialidades.Find(id);

            if (especialidadToDelete != null)
            {
                context.Especialidades.Remove(especialidadToDelete);
                context.SaveChanges();
            }
        }

        public Especialidad? Get(int id)
        {
            using var context = new AcademiaDbContext();

            return context.Especialidades.Find(id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
            using var context = new AcademiaDbContext();

            return context.Especialidades.ToList();
        }

        public void Update(Especialidad especialidad)
        {
            using var context = new AcademiaDbContext();

            Especialidad? especialidadToUpdate = context.Especialidades.Find(especialidad.IdEspecialidad);

            if (especialidadToUpdate != null)
            {
                especialidadToUpdate.Nombre_Especialidad = especialidad.Nombre_Especialidad;
                context.SaveChanges();
            }
        }

        public async Task<Especialidad> GetByNombre(string nombreEspecialiad)
        {
            using var context = new AcademiaDbContext();
            return context.Especialidades.FirstOrDefault(e => e.Nombre_Especialidad == nombreEspecialiad);
        }
    }
}

