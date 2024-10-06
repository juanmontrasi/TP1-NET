﻿using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
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

            context.Add(alumnoInscripcion);
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

        public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = new AcademiaDbContext();
            return context.AlumnoInscripciones.ToList();
        }

        public bool Update(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = new AcademiaDbContext();
            AlumnoInscripcion? alumnoInscripcionToUpdate = context.AlumnoInscripciones.Find(alumnoInscripcion.IdAlumnoInscripcion);
            if (alumnoInscripcionToUpdate != null)
            {
                if (alumnoInscripcion.Condicion == "Aprobada" && alumnoInscripcion.Nota < 6)
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
