using Entidades;
using proyecto_academia.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace proyecto_academia.Servicios
{
    public class PlanesServices
    {
        public bool Add(Plan plan)
        {
            using var context = new AcademiaDbContext();

           
            if (context.Planes.Any(p => p.Nombre_Plan == plan.Nombre_Plan && p.IdEspecialidad == plan.IdEspecialidad))
            {
                return false; 
            }

          
            if (context.Especialidades.Any(e => e.IdEspecialidad == plan.IdEspecialidad))
            {
                context.Planes.Add(plan);
                context.SaveChanges();
                return true; 
            }
            else
            {
                throw new ArgumentException("ID de Especialidad no válido.");
            }
        }


        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();

            Plan? planToDelete = context.Planes.Find(id);

            if (planToDelete != null)
            {
                context.Planes.Remove(planToDelete);
                context.SaveChanges();
            }
        }

        public Plan? Get(int id)
        {
            using var context = new AcademiaDbContext();

            return context.Planes.Find(id);
        }

        public IEnumerable<dynamic> GetAll()
        {
            using var context = new AcademiaDbContext();

            var planesConEspecialidad = (from p in context.Planes
                                         join e in context.Especialidades on p.IdEspecialidad equals e.IdEspecialidad
                                         select new
                                         {
                                             p.IdPlan,
                                             p.Nombre_Plan,
                                             Nombre_Especialidad = e.Nombre_Especialidad
                                         }).ToList();
            return planesConEspecialidad;
            
        }

        public void Update(Plan plan)
        {
            using var context = new AcademiaDbContext();

            Plan? planToUpdate = context.Planes.Find(plan.IdPlan);

            if (planToUpdate != null)
            {
                planToUpdate.Nombre_Plan = plan.Nombre_Plan;
                planToUpdate.IdEspecialidad = plan.IdEspecialidad;
                context.SaveChanges();
            }
        }
    }
}
