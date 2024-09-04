using Microsoft.EntityFrameworkCore;
using Entidades;
/* Contexto para la base de datos usando entity framework para definir tablas, atributos, claves primarias, etc */
namespace proyecto_academia.Context
{
    public class AcademiaDbContext : DbContext
    {
        public AcademiaDbContext(DbContextOptions<AcademiaDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Academia;Trusted_Connection=True;TrustServerCertificate=True;");


            }
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<DocenteCurso> DocenteCursos { get; set; }
        public DbSet<AlumnoInscripcion> AlumnoInscripciones { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Comision> Comisiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Persona
            modelBuilder.Entity<Persona>()
                 .HasKey(c => c.IdPersona);

            modelBuilder.Entity<Persona>()
                .HasMany(p => p.Usuarios)
                .WithOne(u => u.Persona)
                .HasForeignKey(u => u.IdPersona);

            modelBuilder.Entity<Persona>()
                .HasMany(p => p.AlumnoInscripciones)
                .WithOne(a => a.Persona)
                .HasForeignKey(a => a.IdPersona);

            modelBuilder.Entity<Persona>()
                .HasMany(p => p.DocenteCursos)
                .WithOne(d => d.Persona)
                .HasForeignKey(d => d.IdPersona);

            // Configuración de Usuario
            modelBuilder.Entity<Usuario>()
                 .HasKey(c => c.IdUsuario);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.IdPersona);

            // Configuración de Curso
            modelBuilder.Entity<Curso>()
                 .HasKey(c => c.IdCurso); 

            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Materia)
                .WithMany(m => m.Cursos)
                .HasForeignKey(c => c.IdMateria)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Comision)
                .WithMany(co => co.Cursos)
                .HasForeignKey(c => c.IdComision)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Curso>()
                .HasMany(c => c.AlumnoInscripciones)
                .WithOne(a => a.Curso)
                .HasForeignKey(a => a.IdCurso);

            modelBuilder.Entity<Curso>()
                .HasMany(c => c.DocenteCursos)
                .WithOne(d => d.Curso)
                .HasForeignKey(d => d.IdCurso);

            // Configuración de DocenteCurso
            modelBuilder.Entity<DocenteCurso>()
                   .HasKey(d => d.IdDocenteCurso); 

            modelBuilder.Entity<DocenteCurso>()
                .HasOne(d => d.Persona)
                .WithMany(p => p.DocenteCursos)
                .HasForeignKey(d => d.IdPersona);

            modelBuilder.Entity<DocenteCurso>()
                .HasOne(d => d.Curso)
                .WithMany(c => c.DocenteCursos)
                .HasForeignKey(d => d.IdCurso);

            modelBuilder.Entity<AlumnoInscripcion>()
                .HasKey(a => a.IdAlumnoInscripcion);

            modelBuilder.Entity<AlumnoInscripcion>()
                .HasOne(a => a.Persona)
                .WithMany(p => p.AlumnoInscripciones)
                .HasForeignKey(a => a.IdPersona);

            modelBuilder.Entity<AlumnoInscripcion>()
                .HasOne(a => a.Curso)
                .WithMany(c => c.AlumnoInscripciones)
                .HasForeignKey(a => a.IdCurso);

            // Configuración de Materia
            modelBuilder.Entity<Materia>()
                .HasKey(m  => m.IdMateria);
            modelBuilder.Entity<Materia>()
                .HasMany(m => m.Cursos)
                .WithOne(c => c.Materia)
                .HasForeignKey(c => c.IdMateria);

            // Configuración de Plan
            modelBuilder.Entity<Plan>()
                 .HasKey(c => c.IdPlan);

            modelBuilder.Entity<Plan>()
                .HasMany(p => p.Personas)
                .WithOne(pe => pe.Plan)
                .HasForeignKey(pe => pe.IdPlan);

            modelBuilder.Entity<Plan>()
                .HasMany(p => p.Materias)
                .WithOne(m => m.Plan)
                .HasForeignKey(m => m.IdPlan);

            modelBuilder.Entity<Plan>()
                .HasMany(p => p.Comisiones)
                .WithOne(co => co.Plan)
                .HasForeignKey(co => co.IdPlan);

            // Configuración de Especialidad
            modelBuilder.Entity<Especialidad>()
                .HasKey(e => e.IdEspecialidad);

            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.Planes)
                .WithOne(p => p.Especialidad)
                .HasForeignKey(p => p.IdEspecialidad);

            // Configuración de Comision
            modelBuilder.Entity<Comision>()
                .HasKey(c => c.IdComision); 

            modelBuilder.Entity<Comision>()
                .HasMany(c => c.Cursos)
                .WithOne(cu => cu.Comision)
                .HasForeignKey(cu => cu.IdComision);
        }
    }
}
