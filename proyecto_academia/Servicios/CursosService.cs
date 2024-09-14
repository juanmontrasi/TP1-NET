using Entidades;
using proyecto_academia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_academia.Servicios
{
    public class CursosService
    {
        public void Add(Curso curso)
        {
            using var context = new AcademiaDbContext();

            if (context.Comisiones.Any(c => c.IdComision == curso.IdComision) && context.Materias.Any(m => m.IdMateria== curso.IdMateria))
            {
                context.Cursos.Add(curso);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("IDs no válidos.");
            }
        }
        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();

            Curso? cursoToDelete = context.Cursos.Find(id);

            if (cursoToDelete != null)
            {
                context.Cursos.Remove(cursoToDelete);
                context.SaveChanges();
            }
        }

        public Curso? Get(int id)
        {
            using var context = new AcademiaDbContext();

            return context.Cursos.Find(id);
        }

        public IEnumerable<Curso> GetAll()
        {
            using var context = new AcademiaDbContext();


            return context.Cursos.ToList();
        }

        public void Update(Curso curso)
        {
            using var context = new AcademiaDbContext();

            Curso? cursoToUpdate = context.Cursos.Find(curso.IdCurso);

            if (cursoToUpdate != null)
            {
                cursoToUpdate.Nombre = curso.Nombre;
                cursoToUpdate.Cupo = curso.Cupo;
                cursoToUpdate.Anio_Calendario = curso.Anio_Calendario;
                context.SaveChanges();
            }
        }
    }
}
