using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;
using proyecto_academia.Context;


namespace proyecto_academia.Servicios
{
    public class AlumnoInscripcionesService
    {
        public bool Add(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = new AcademiaDbContext();

            if (context.AlumnoInscripciones.Any(ai => ai.IdPersona == alumnoInscripcion.IdPersona && ai.IdCurso == alumnoInscripcion.IdCurso))
            {
                return false;
            }

            var curso = context.Cursos.Find(alumnoInscripcion.IdCurso);
            if (curso == null || curso.Cupo <= 0)
            {
                return false; 
            }

            
            context.AlumnoInscripciones.Add(alumnoInscripcion);

            
            curso.Cupo -= 1;
            context.Cursos.Update(curso);

            
            context.SaveChanges();

            return true;
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
            return context.AlumnoInscripciones.Find(id);
        }

        /*public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = new AcademiaDbContext();
            return context.AlumnoInscripciones.ToList();
        }*/

        public IEnumerable<dynamic> GetAll()
        {
            using var context = new AcademiaDbContext();

            var alumnoInscripcionesConDetalles = (from ai in context.AlumnoInscripciones
                                                  join p in context.Personas on ai.IdPersona equals p.IdPersona
                                                  join c in context.Cursos on ai.IdCurso equals c.IdCurso
                                                  select new
                                                  {
                                                      ai.IdAlumnoInscripcion,
                                                      ai.IdPersona,
                                                      ai.IdCurso,
                                                      ai.Nota,
                                                      ai.Condicion,
                                                      PersonaNombre = p.Nombre,
                                                      PersonaApellido = p.Apellido,
                                                      CursoNombre = c.Nombre
                                                  }).ToList();
            return alumnoInscripcionesConDetalles;
        }



        public bool Update(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = new AcademiaDbContext();
            AlumnoInscripcion? alumnoInscripcionToUpdate = context.AlumnoInscripciones.Find(alumnoInscripcion.IdAlumnoInscripcion);
            if (alumnoInscripcionToUpdate != null)
            {
                if ((alumnoInscripcion.Condicion == "Aprobada" && alumnoInscripcion.Nota < 6) || (alumnoInscripcion.Condicion == "Aprobada" && alumnoInscripcion.Nota > 10))
                {
                    return false; 
                }

                if (alumnoInscripcion.Nota < 1 || alumnoInscripcion.Nota > 10)
                {
                    return false;
                }


                if (alumnoInscripcion.Condicion != "Aprobada")
                {
                    alumnoInscripcion.Nota = 0;
                }

                alumnoInscripcionToUpdate.Condicion = alumnoInscripcion.Condicion;
                alumnoInscripcionToUpdate.Nota = alumnoInscripcion.Nota;
                alumnoInscripcionToUpdate.IdCurso = alumnoInscripcion.IdCurso;
                alumnoInscripcionToUpdate.IdPersona = alumnoInscripcion.IdPersona;
                context.SaveChanges();
                return true; 
            }
            else
            {
                throw new InvalidOperationException("No se encontró la inscripción para actualizar.");
            }
        }

        public List<AlumnoInscripcion> GetByAlumnoId(int idPersona)
        {
            using var context = new AcademiaDbContext();
            return context.AlumnoInscripciones.Where(inscripcion => inscripcion.IdPersona == idPersona).ToList();
        }
    }
}
