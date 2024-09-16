using System;
using System.Collections.Generic;


namespace Entidades
{
    //ENUM TIPO PERSONA 
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public int IdPlan { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }
        public string FechaNacimiento { get; set; }
        public int Legajo { get; set; }

        // Relaciones
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<DocenteCurso> DocenteCursos { get; set; }
        public ICollection<AlumnoInscripcion> AlumnoInscripciones { get; set; }
        public Plan Plan { get; set; }

        

        
    }

    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public IEnumerable<string> Rol { get; set; } // Puede ser "Estudiante" o "Profesor"
        public string Nombre_Usuario { get; set; }
        public string Clave { get; set; }
        public int Habilitado { get; set; }

        // Relaciones
        public Persona Persona { get; set; }
        public ICollection<DocenteCurso> DocenteCursos { get; set; }
        public ICollection<AlumnoInscripcion> AlumnoInscripciones { get; set; }

        
    }

    public class Curso
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public int IdComision { get; set; }
        public int IdMateria { get; set; }
        public int Cupo { get; set; }
        public int Anio_Calendario { get; set; }
        // Relaciones
        public Materia Materia { get; set; }
        public Comision Comision { get; set; }
        public ICollection<AlumnoInscripcion> AlumnoInscripciones { get; set; }
        public ICollection<DocenteCurso> DocenteCursos { get; set; }
    }

    public class DocenteCurso
    {
        public int IdDocenteCurso { get; set; }
        public int IdPersona { get; set; }
        public int IdCurso { get; set; }
        public int Cargo { get; set; }

        // Relaciones
        public Persona Persona { get; set; }
        public Curso Curso { get; set; }
    }

    public class AlumnoInscripcion
    {
        public int IdAlumnoInscripcion { get; set; }
        public int IdPersona { get; set; }
        public int IdCurso { get; set; }
        public int Cupo { get; set; }
        public string Condicion { get; set; }

        // Relaciones
        public Persona Persona { get; set; }
        public Curso Curso { get; set; }
    }

    public class Materia
    {
        public int IdMateria { get; set; }
        public string Nombre_Materia { get; set; }
        public int IdPlan { get; set; }
        public int Hs_Semanales { get; set; }
        public int Hs_Totales { get; set; }

        // Relaciones
        public ICollection<Curso> Cursos { get; set; }
        public Plan Plan { get; set; }
    }

    public class Plan
    {
        public int IdPlan { get; set; }
        public string Nombre_Plan { get; set; }
        public int IdEspecialidad { get; set; }

        // Relaciones
        public ICollection<Persona> Personas { get; set; }
        public ICollection<Materia> Materias { get; set; }
        public Especialidad Especialidad { get; set; }
        public ICollection<Comision> Comisiones { get; set; }
    }

    public class Especialidad
    {
        public int IdEspecialidad { get; set; }
        public string Nombre_Especialidad { get; set; }

        // Relaciones
        public ICollection<Plan> Planes { get; set; }
    }

    public class Comision
    {
        public int IdComision { get; set; }
        public string Nombre_Comision { get; set; }
        public int IdPlan { get; set; }
        public int Anio_Especialidad { get; set; }
        // Relaciones
        public Plan Plan { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}
