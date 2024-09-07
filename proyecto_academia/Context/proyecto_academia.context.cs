using System;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySqlX.XDevAPI;

/* Uso de interfaz IDesignTimeDbContextFactory<T> que crea instancias de DbContext para hacer migraciones a nuestra base de datos */

namespace proyecto_academia.Context
{
    public class AcademiaDbContextFactory : IDesignTimeDbContextFactory<AcademiaDbContext>
    {
        public AcademiaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AcademiaDbContext>();

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Academia;Trusted_Connection=True;TrustServerCertificate=True;");


            return new AcademiaDbContext(optionsBuilder.Options);
        }
        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();

            Especialidad? EspecialidadToDelete = context.Especialidades.Find(id);

            if (EspecialidadToDelete != null)
            {
                context.Especialidades.Remove(EspecialidadToDelete);
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

            Especialidad? EspecialidadToUpdate = context.Especialidades.Find(especialidad.IdEspecialidad);

            if (EspecialidadToUpdate != null)
            {
                EspecialidadToUpdate.Nombre_Especialidad = especialidad.Nombre_Especialidad;
                context.SaveChanges();
            }
        }
    }
}
