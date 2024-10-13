﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyecto_academia.Context;

#nullable disable

namespace proyecto_academia.Migrations
{
    [DbContext(typeof(AcademiaDbContext))]
    partial class AcademiaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entidades.AlumnoInscripcion", b =>
                {
                    b.Property<int>("IdAlumnoInscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlumnoInscripcion"));

                    b.Property<string>("Condicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdAlumnoInscripcion");

                    b.HasIndex("IdCurso");

                    b.HasIndex("IdPersona");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("AlumnoInscripciones");
                });

            modelBuilder.Entity("Entidades.Comision", b =>
                {
                    b.Property<int>("IdComision")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComision"));

                    b.Property<int>("Anio_Especialidad")
                        .HasColumnType("int");

                    b.Property<int>("IdPlan")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Comision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdComision");

                    b.HasIndex("IdPlan");

                    b.ToTable("Comisiones");
                });

            modelBuilder.Entity("Entidades.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCurso"));

                    b.Property<int>("Anio_Calendario")
                        .HasColumnType("int");

                    b.Property<int>("Cupo")
                        .HasColumnType("int");

                    b.Property<int>("IdComision")
                        .HasColumnType("int");

                    b.Property<int>("IdMateria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCurso");

                    b.HasIndex("IdComision");

                    b.HasIndex("IdMateria");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Entidades.DocenteCurso", b =>
                {
                    b.Property<int>("IdDocenteCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDocenteCurso"));

                    b.Property<int>("Cargo")
                        .HasColumnType("int");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdDocenteCurso");

                    b.HasIndex("IdCurso");

                    b.HasIndex("IdPersona");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("DocenteCursos");
                });

            modelBuilder.Entity("Entidades.Especialidad", b =>
                {
                    b.Property<int>("IdEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEspecialidad"));

                    b.Property<string>("Nombre_Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEspecialidad");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Entidades.Materia", b =>
                {
                    b.Property<int>("IdMateria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMateria"));

                    b.Property<int>("Hs_Semanales")
                        .HasColumnType("int");

                    b.Property<int>("Hs_Totales")
                        .HasColumnType("int");

                    b.Property<int>("IdPlan")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Materia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMateria");

                    b.HasIndex("IdPlan");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Entidades.Persona", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersona");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Entidades.Plan", b =>
                {
                    b.Property<int>("IdPlan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlan"));

                    b.Property<int>("IdEspecialidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Plan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPlan");

                    b.HasIndex("IdEspecialidad");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Habilitado")
                        .HasColumnType("int");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdPersona");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Entidades.AlumnoInscripcion", b =>
                {
                    b.HasOne("Entidades.Curso", "Curso")
                        .WithMany("AlumnoInscripciones")
                        .HasForeignKey("IdCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Persona", "Persona")
                        .WithMany("AlumnoInscripciones")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Usuario", null)
                        .WithMany("AlumnoInscripciones")
                        .HasForeignKey("UsuarioIdUsuario");

                    b.Navigation("Curso");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Entidades.Comision", b =>
                {
                    b.HasOne("Entidades.Plan", "Plan")
                        .WithMany("Comisiones")
                        .HasForeignKey("IdPlan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Entidades.Curso", b =>
                {
                    b.HasOne("Entidades.Comision", "Comision")
                        .WithMany("Cursos")
                        .HasForeignKey("IdComision")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Materia", "Materia")
                        .WithMany("Cursos")
                        .HasForeignKey("IdMateria")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comision");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Entidades.DocenteCurso", b =>
                {
                    b.HasOne("Entidades.Curso", "Curso")
                        .WithMany("DocenteCursos")
                        .HasForeignKey("IdCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Persona", "Persona")
                        .WithMany("DocenteCursos")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Usuario", null)
                        .WithMany("DocenteCursos")
                        .HasForeignKey("UsuarioIdUsuario");

                    b.Navigation("Curso");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Entidades.Materia", b =>
                {
                    b.HasOne("Entidades.Plan", "Plan")
                        .WithMany("Materias")
                        .HasForeignKey("IdPlan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Entidades.Plan", b =>
                {
                    b.HasOne("Entidades.Especialidad", "Especialidad")
                        .WithMany("Planes")
                        .HasForeignKey("IdEspecialidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.HasOne("Entidades.Persona", "Persona")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Entidades.Comision", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("Entidades.Curso", b =>
                {
                    b.Navigation("AlumnoInscripciones");

                    b.Navigation("DocenteCursos");
                });

            modelBuilder.Entity("Entidades.Especialidad", b =>
                {
                    b.Navigation("Planes");
                });

            modelBuilder.Entity("Entidades.Materia", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("Entidades.Persona", b =>
                {
                    b.Navigation("AlumnoInscripciones");

                    b.Navigation("DocenteCursos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Entidades.Plan", b =>
                {
                    b.Navigation("Comisiones");

                    b.Navigation("Materias");
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.Navigation("AlumnoInscripciones");

                    b.Navigation("DocenteCursos");
                });
#pragma warning restore 612, 618
        }
    }
}
