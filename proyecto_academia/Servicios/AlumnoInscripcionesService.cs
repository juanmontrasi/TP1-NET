using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using proyecto_academia.Context;

namespace proyecto_academia.Servicios
{
     public class AlumnoInscripcionesService
    {
        public void Add(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = new AcademiaDbContext();
            context.Add(alumnoInscripcion);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();
            AlumnoInscripcion? alumnoInscripcionToDelete = context.AlumnoInscripciones.Find(id);
            if (alumnoInscripcionToDelete != null)
            {
                context.AlumnoInscripciones.Remove(alumnoInscripcionToDelete);
                context.SaveChanges();
            }
        }

        public AlumnoInscripcion? Get(int id)
        {
            using var context = new AcademiaDbContext();
            AlumnoInscripcion? alumnoInscripcion = context.AlumnoInscripciones.Find(id);
            return alumnoInscripcion;
        }

        public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = new AcademiaDbContext();
            return context.AlumnoInscripciones.ToList();
        }

        public void Update(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = new AcademiaDbContext();
            AlumnoInscripcion? alumnoInscripcionToUpdate = context.AlumnoInscripciones.Find(alumnoInscripcion.IdAlumnoInscripcion);
            if(alumnoInscripcionToUpdate != null)
            {
                alumnoInscripcionToUpdate.Condicion = alumnoInscripcion.Condicion;
                alumnoInscripcionToUpdate.Nota = alumnoInscripcion.Nota;
                alumnoInscripcionToUpdate.IdCurso = alumnoInscripcion.IdCurso;
                alumnoInscripcionToUpdate.IdPersona = alumnoInscripcion.IdPersona;
                context.SaveChanges();
            }
        }
    }
}
