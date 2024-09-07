using Entidades;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_academia.Context;
namespace proyecto_academia.Servicios
{
    public  class EspecialidadesServicecs
    {
        public void Add(Especialidad especialidad)
        {
            using var context = new AcademiaDbContext();

            context.Especialidades.Add(especialidad);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();

            Especialidad? especialidadToDelete = context.Especialidades.Find(id);

            if (especialidadToDelete != null)
            {
                context.Especialidades.Remove(especialidadToDelete);
                context.SaveChanges();
            }
        }

        public Especialidad? Get(int id)
        {
            using var context = new AcademiaDbContext();

            return context.Especialidades.Find(id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
            using var context = new AcademiaDbContext();

            return context.Especialidades.ToList();
        }

        public void Update(Especialidad especialidad)
        {
            using var context = new AcademiaDbContext();

            Especialidad? especialidadToUpdate = context.Especialidades.Find(especialidad.IdEspecialidad);

            if (especialidadToUpdate != null)
            {
                especialidadToUpdate.Nombre_Especialidad = especialidad.Nombre_Especialidad;
                context.SaveChanges();
            }
        }
    }
}
