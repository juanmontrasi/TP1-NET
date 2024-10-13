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
        
    }
}
