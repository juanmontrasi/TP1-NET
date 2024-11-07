using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using proyecto_academia.Context;

namespace proyecto_academia.Servicios
{
    public class DocenteCursoService
    {
        public bool Add(DocenteCurso docenteCurso)
        {
            using var context = new AcademiaDbContext();

            
            if (docenteCurso.Cargo != 1 && docenteCurso.Cargo != 2)
            {
                throw new ArgumentException("Cargo inválido. Debe ser 1 (Teoría) o 2 (Práctica).");
            }

            
            if (context.DocenteCursos.Any(a => a.IdPersona == docenteCurso.IdPersona &&
                                               a.IdCurso == docenteCurso.IdCurso &&
                                               a.Cargo == docenteCurso.Cargo))
            {
                return false; 
            }

            
            if (context.Personas.Any(p => p.IdPersona == docenteCurso.IdPersona) &&
                context.Cursos.Any(c => c.IdCurso == docenteCurso.IdCurso))
            {
                context.Add(docenteCurso);
                context.SaveChanges(); 
                return true; 
            }
            else
            {
                throw new ArgumentException("IDs no válidos."); 
            }
        }




        public DocenteCurso Get(int id)
        {
            using var context = new AcademiaDbContext();

            return context.DocenteCursos.Find(id);
        }

        public IEnumerable<dynamic> GetAll()
        {
            using var context = new AcademiaDbContext();

            var cursosDocente = (from dc in context.DocenteCursos
                                 join c in context.Cursos on dc.IdCurso equals c.IdCurso
                                 join p in context.Personas on dc.IdPersona equals p.IdPersona
                                 select new
                                 {
                                     dc.IdDocenteCurso,
                                     dc.Cargo,
                                     Nombre_Persona = p.Nombre,
                                     Apellido_Persona = p.Apellido,
                                     Nombre_Curso = c.Nombre
                                 }).ToList();

            return cursosDocente;
        }

        public bool Update(DocenteCurso docenteCurso)
        {
            using var context = new AcademiaDbContext();

            DocenteCurso? docenteCursoToUpdate = context.DocenteCursos.Find(docenteCurso.IdDocenteCurso);

            if(docenteCursoToUpdate != null)
            {
                docenteCursoToUpdate.Cargo = docenteCurso.Cargo;
                docenteCursoToUpdate.IdCurso = docenteCurso.IdCurso;
                docenteCursoToUpdate.IdPersona = docenteCurso.IdPersona;
                context.Update(docenteCursoToUpdate);
                context.SaveChanges();
                return true;
            }
            else
            {
                throw new InvalidOperationException("No se encontró la Asingacion para actualizar.");
            }

        }

        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();

            DocenteCurso? docenteCursoToDelete = context.DocenteCursos.Find(id);

            if(docenteCursoToDelete != null)
            {
                context.Remove(docenteCursoToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se encontró la Asingacion para Eliminar.");
            }

        }

        public IEnumerable<dynamic> GetByDocenteId(int id)
        {
            using var context = new AcademiaDbContext();

            var cursosDocente = (from dc in context.DocenteCursos
                                 join c in context.Cursos on dc.IdCurso equals c.IdCurso
                                 join p in context.Personas on dc.IdPersona equals p.IdPersona
                                 where dc.IdPersona == id
                                 select new
                                 {
                                     dc.IdDocenteCurso,
                                     dc.Cargo,
                                     Nombre_Persona = p.Nombre,
                                     Apellido_Persona = p.Apellido,
                                     Nombre_Curso = c.Nombre
                                 }).ToList();

            return cursosDocente;
        }

    }
}
