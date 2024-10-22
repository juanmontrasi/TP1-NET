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

        public List<DocenteCurso> GetAll()
        {
            using var context = new AcademiaDbContext();

            return context.DocenteCursos.ToList();
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

        public List<DocenteCurso> GetByDocenteId(int id)
        {
            using var context = new AcademiaDbContext();

            return context.DocenteCursos.Where(d => d.IdPersona == id).ToList();
        }

    }
}
