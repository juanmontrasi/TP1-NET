using Entidades;
using proyecto_academia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace proyecto_academia.Servicios
{
    public class PlanesServices
    {
        public void Add(Plan plan)
        {
            using var context = new AcademiaDbContext();

            if (context.Especialidades.Any(e => e.IdEspecialidad == plan.IdEspecialidad))
            {
                context.Planes.Add(plan);
                context.SaveChanges();
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

        public IEnumerable<Plan> GetAll()
        {
            using var context = new AcademiaDbContext();

            return context.Planes.ToList();
        }

        public void Update(Plan plan)
        {
            using var context = new AcademiaDbContext();

            Plan? planToUpdate = context.Planes.Find(plan.IdPlan);

            if (planToUpdate != null)
            {
                planToUpdate.Nombre_Plan = plan.Nombre_Plan;
                context.SaveChanges();
            }
        }
    }
}
