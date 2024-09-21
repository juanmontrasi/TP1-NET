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
    public class ComisionesService
    {
        public void Add(Comision comision)
        {
            using var context = new AcademiaDbContext();

            if (context.Planes.Any(p => p.IdPlan == comision.IdPlan))
            {
                context.Comisiones.Add(comision);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("ID de Plan no válido.");
            }
        }
        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();

            Comision? comisionToDelete = context.Comisiones.Find(id);

            if (comisionToDelete != null)
            {
                context.Comisiones.Remove(comisionToDelete);
                context.SaveChanges();
            }
        }

        public Comision? Get(int id)
        {
            using var context = new AcademiaDbContext();

            return context.Comisiones.Find(id);
        }

        public IEnumerable<Comision> GetAll()
        {
            using var context = new AcademiaDbContext();

            return context.Comisiones.ToList();
        }

        public void Update(Comision comision)
        {
            using var context = new AcademiaDbContext();

            Comision? comisionToUpdate = context.Comisiones.Find(comision.IdComision);

            if (comisionToUpdate != null)
            {
                comisionToUpdate.Nombre_Comision = comision.Nombre_Comision;
                comisionToUpdate.Anio_Especialidad = comision.Anio_Especialidad;
                comisionToUpdate.IdPlan = comision.IdPlan;
                context.SaveChanges();
            }
        }
        
    }
}
