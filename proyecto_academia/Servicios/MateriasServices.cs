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
    public class MateriasServices
    {
        public bool Add(Materia materia)
        {
            using var context = new AcademiaDbContext();

            if (context.Materias.Any(p => p.Nombre_Materia== materia.Nombre_Materia))
            {
                return false;
            }

            if (context.Planes.Any(p => p.IdPlan == materia.IdPlan))
            {
                context.Materias.Add(materia);
                context.SaveChanges();
                return true;    
            }
            else
            {
                throw new ArgumentException("ID de Plan no válido.");
            }
        }
        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();

            Materia? materiaToDelete = context.Materias.Find(id);

            if (materiaToDelete != null)
            {
                context.Materias.Remove(materiaToDelete);
                context.SaveChanges();
            }
        }

        public Materia? Get(int id)
        {
            using var context = new AcademiaDbContext();

            return context.Materias.Find(id);
        }

        public IEnumerable<dynamic> GetAll()
        {
            using var context = new AcademiaDbContext();

            var materiasConPlan = (from m in context.Materias
                                   join p in context.Planes on m.IdPlan equals p.IdPlan
                                   select new
                                   {
                                       m.IdMateria,
                                       m.Nombre_Materia,
                                       m.Hs_Semanales,
                                       m.Hs_Totales,
                                       Nombre_Plan = p.Nombre_Plan
                                   }).ToList();
            return materiasConPlan;
        }

        public void Update(Materia materia)
        {
            using var context = new AcademiaDbContext();

            Materia? materiaToUpdate = context.Materias.Find(materia.IdMateria);

            if (materiaToUpdate != null)
            {
                materiaToUpdate.Nombre_Materia = materia.Nombre_Materia;
                materiaToUpdate.Hs_Semanales = materia.Hs_Semanales;
                materiaToUpdate.Hs_Totales = materia.Hs_Totales;
                materiaToUpdate.IdPlan = materia.IdPlan;
                context.SaveChanges();
            }
        }
    }
}
