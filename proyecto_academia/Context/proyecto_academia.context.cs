using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
