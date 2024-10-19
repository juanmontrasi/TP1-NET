using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;
using proyecto_academia.Servicios;
using Entidades;

var builder = WebApplication.CreateBuilder(args);

// Otras configuraciones...
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.MaxDepth = 64;
    });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpLogging();
        }


        app.MapGet("/especialidades/{id}", (int id) =>
        {
            EspecialidadesServicecs especialidadesServicecs = new EspecialidadesServicecs();

            return especialidadesServicecs.Get(id);
        })
        .WithName("GetEspecialidad")
        .WithOpenApi();
        app.MapGet("/especialidades", () =>
        {
            EspecialidadesServicecs especialidadService = new EspecialidadesServicecs();

            return especialidadService.GetAll();
        })
        .WithName("GetAllEspecialidades")
        .WithOpenApi();

        app.MapPost("/especialidades", (Especialidad especialidad) =>
        {
            EspecialidadesServicecs especialidadesServicecs = new EspecialidadesServicecs();

            bool creada = especialidadesServicecs.Add(especialidad);
            if (!creada)
            {
                return Results.Conflict("Ya existe una especialidad con los mismo datos");
            }
            return Results.Ok(especialidad);
        })
        .WithName("AddEspecialidad")
        .WithOpenApi();

        app.MapPut("/especialidades", (Especialidad especialidad) =>
        {
            EspecialidadesServicecs especialidadService = new EspecialidadesServicecs();

            especialidadService.Update(especialidad);
        })
        .WithName("UpdateEspecialidad")
        .WithOpenApi();

        app.MapDelete("/especialidades/{id}", (int id) =>
        {
            EspecialidadesServicecs especialidadService = new EspecialidadesServicecs();

            especialidadService.Delete(id);
        })
        .WithName("DeleteEspecialidad")
        .WithOpenApi();


        // Materias

        app.MapGet("/materias/{id}", (int id) =>
        {
            MateriasServices materiasServices = new MateriasServices();

            return materiasServices.Get(id);
        })
        .WithName("GetMateria")
        .WithOpenApi();
        app.MapGet("/materias", () =>
        {
            MateriasServices materiasServices = new MateriasServices();

            return materiasServices.GetAll();
        })
        .WithName("GetAllMaterias")
        .WithOpenApi();

        app.MapPost("/materias", (Materia materia) =>
        {
            MateriasServices materiasServices = new MateriasServices();

            bool creada = materiasServices.Add(materia);
            if (!creada)
            {
                return Results.Conflict("Ya existe una materia con los mismo datos");
            }
            return Results.Ok(materia);
        })
        .WithName("AddMateria")
        .WithOpenApi();

        app.MapPut("/materias", (Materia materia) =>
        {
            MateriasServices materiasServices = new MateriasServices();

            materiasServices.Update(materia);
        })
        .WithName("UpdateMateria")
        .WithOpenApi();

        app.MapDelete("/materias/{id}", (int id) =>
        {
            MateriasServices materiasServices = new MateriasServices();

            materiasServices.Delete(id);
        })
        .WithName("DeleteMateria")
        .WithOpenApi();

        // Cursos

        app.MapGet("/cursos/{id}", (int id) =>
        {
            CursosService cursosService = new CursosService();

            return cursosService.Get(id);
        })
        .WithName("GetCurso")
        .WithOpenApi();
        app.MapGet("/cursos", () =>
        {
            CursosService cursosService = new CursosService();

            return cursosService.GetAll();
        })
        .WithName("GetAllCursos")
        .WithOpenApi();

        app.MapPost("/cursos", (Curso curso) =>
        {
            CursosService cursosServices = new CursosService();

            bool creada = cursosServices.Add(curso);
            if (!creada)
            {
                return Results.Conflict("Ya existe curso con los mismo datos");
            }
            return Results.Ok(curso);
        })
        .WithName("AddCurso")
        .WithOpenApi();

        app.MapPut("/cursos", (Curso curso) =>
        {
            CursosService cursosServices = new CursosService();

            cursosServices.Update(curso);
        })
        .WithName("UpdateCurso")
        .WithOpenApi();

        app.MapDelete("/cursos/{id}", (int id) =>
        {
            CursosService cursosServices = new CursosService();

            cursosServices.Delete(id);
        })
        .WithName("DeleteCurso")
        .WithOpenApi();

        // Comisiones

        app.MapGet("/comisiones/{id}", (int id) =>
        {
            ComisionesService comisionesService = new ComisionesService();

            return comisionesService.Get(id);
        })
        .WithName("GetComision")
        .WithOpenApi();
        app.MapGet("/comisiones", () =>
        {
            ComisionesService comisionesService = new ComisionesService();

            return comisionesService.GetAll();
        })
        .WithName("GetAllComisiones")
        .WithOpenApi();

        app.MapPost("/comisiones", (Comision comision) =>
        {
            ComisionesService comisionesService = new ComisionesService();

            bool creada = comisionesService.Add(comision);
            if (!creada)
            {
                return Results.Conflict("Ya existe una comision con los mismo datos");
            }
            return Results.Ok(comision);
        })
        .WithName("AddComision")
        .WithOpenApi();

        app.MapPut("/comisiones", (Comision comision) =>
        {
            ComisionesService comisionesService = new ComisionesService();

            comisionesService.Update(comision);
        })
        .WithName("UpdateComision")
        .WithOpenApi();

        app.MapDelete("/comisiones/{id}", (int id) =>
        {
            ComisionesService comisionesService = new ComisionesService();

            comisionesService.Delete(id);
        })
        .WithName("DeleteComision")
        .WithOpenApi();

        app.MapGet("/planes/{id}", (int id) =>
        {
            PlanesServices planesService = new PlanesServices();

            return planesService.Get(id);
        })
        .WithName("GetPlan")
        .WithOpenApi();
        app.MapGet("/planes", () =>
        {
            PlanesServices planService = new PlanesServices();

            return planService.GetAll();
        })
        .WithName("GetAllPlanes")
        .WithOpenApi();

        app.MapPost("/planes", (Plan plan) =>
        {
            PlanesServices planesService = new PlanesServices();

            bool creado = planesService.Add(plan);
            if (!creado)
            {
                return Results.Conflict("Ya existe un Plan con ese Nombre en esa Especialidad");
            }
            return Results.Ok(plan);
        })
        .WithName("AddPlan")
        .WithOpenApi();

        app.MapPut("/planes", (Plan plan) =>
        {
            PlanesServices planesService = new PlanesServices();

            planesService.Update(plan);
        })
        .WithName("UpdatePlan")
        .WithOpenApi();

        app.MapDelete("/planes/{id}", (int id) =>
        {
            PlanesServices planService = new PlanesServices();

            planService.Delete(id);
        });
        //Persona

        app.MapGet("personas/{id}", (int id) =>
        {
            PersonaService personaService = new PersonaService();
            return personaService.Get(id);
        })
            .WithName("GetPersona")
            .WithOpenApi();
        app.MapGet("/personas", () =>
        {
            PersonaService personaService = new PersonaService();
            return personaService.GetAll();
        })
            .WithName("GetAllPersonas")
            .WithOpenApi();
        app.MapGet("/personas/GetPersonaCreated", (string Nombre, string Apellido, string FechaNacimiento) =>
        {
            PersonaService personaService = new PersonaService();
            return personaService.GetPersonaCreated(Nombre, Apellido, FechaNacimiento);
        });



        app.MapPost("/personas", (Persona persona) =>
        {
            PersonaService personaService = new PersonaService();

            bool creada = personaService.Add(persona);

            if (!creada)
            {
                return Results.Conflict("Ya existe una persona con los mismos datos.");
            }

            return Results.Ok(persona);
        })
        .WithName("AddPersona")
        .WithOpenApi();

        app.MapPut("/personas", (Persona persona) =>
        {
            PersonaService personaService = new PersonaService();
            personaService.Update(persona);
        })
            .WithName("UpdatePersona")
            .WithOpenApi();
        app.MapDelete("/personas/{id}", (int id) =>
        {
            PersonaService personaService = new PersonaService();
            personaService.Delete(id);
        })
            .WithName("DeletePersona")
            .WithOpenApi();


        //Usuario

        app.MapGet("usuarios/{id}", (int id) =>
        {
            UsuarioService usuarioService = new UsuarioService();
            return usuarioService.Get(id);
        })
            .WithName("GetUsuario")
            .WithOpenApi();
        app.MapGet("/usuarios", () =>
        {
            UsuarioService usuarioService = new UsuarioService();
            return usuarioService.GetAll();
        })
            .WithName("GetAllUsuario")
            .WithOpenApi();
        app.MapPost("/usuarios", (Usuario usuario) =>
        {
            UsuarioService usuarioService = new UsuarioService();

            bool creada = usuarioService.Add(usuario);
            if (!creada)
            {
                return Results.Conflict("Ya existe un usuario con los mismo datos");
            }
            return Results.Ok(usuario);
        })
            .WithName("AddUsuario")
            .WithOpenApi();
        app.MapPut("/usuarios", (Usuario usuario) =>
        {
            UsuarioService usuarioService = new UsuarioService();
            usuarioService.Update(usuario);
        })
            .WithName("UpdateUsuario")
            .WithOpenApi();
        app.MapDelete("/usuarios/{id}", (int id) =>
        {
            UsuarioService usuarioService = new UsuarioService();
            usuarioService.Delete(id);
        })
            .WithName("DeleteUsuario")
            .WithOpenApi();

        app.MapPost("/usuarios/authenticate", (Usuario loginUsuario) =>
        {
            UsuarioService usuarioService = new UsuarioService();
            var usuario = usuarioService.Authenticate(loginUsuario.Nombre_Usuario, loginUsuario.Clave);
            if (usuario != null)
            {
                return Results.Ok(usuario);
            }
            return Results.Unauthorized();
        })
        .WithName("AuthenticateUsuario")
        .WithOpenApi();
        //AlumnoInscripciones

        app.MapGet("alumnoinscripciones/{id}", (int id) =>
        {
            AlumnoInscripcionesService alumnoInscripcion = new AlumnoInscripcionesService();
            return alumnoInscripcion.Get(id);
        })
            .WithName("GetAlumnoInscripcion")
            .WithOpenApi();
        app.MapGet("/alumnoinscripciones", () =>
        {
            AlumnoInscripcionesService alumnoInscripcion = new AlumnoInscripcionesService();
            return alumnoInscripcion.GetAll();
        })
            .WithName("GetAllAlumnoInscripciones")
            .WithOpenApi();

        app.MapPost("/alumnoinscripciones", (AlumnoInscripcion alumnoInscripcion) =>
        {
            try
            {
                AlumnoInscripcionesService alumnoInscripcionService = new AlumnoInscripcionesService();
                bool creada = alumnoInscripcionService.Add(alumnoInscripcion);
                if (!creada)
                {
                    return Results.Conflict("Inscripcion ya creada de curso o No hay cupo en el curso");
                }
                return Results.Ok(alumnoInscripcion);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return Results.Problem("Error inesperado en el servidor.");
            }
        }).WithName("AgregarAlumnoInscripciones")
            .WithOpenApi();


        app.MapPut("/alumnoinscripciones", (AlumnoInscripcion alumnoInscripcion) =>
        {
            AlumnoInscripcionesService alumnoInscripcionesService = new AlumnoInscripcionesService();
            bool actualizada = alumnoInscripcionesService.Update(alumnoInscripcion);
            if (!actualizada)
            {
                return Results.Conflict("Error al actualizar la inscripcion");
            }
            return Results.Ok(actualizada);
        })
            .WithName("UpdateAlumnoInscripciones")
            .WithOpenApi();

        app.MapDelete("/alumnoinscripciones/{id}", (int id) =>
        {
            AlumnoInscripcionesService alumnoInscripcionesService = new AlumnoInscripcionesService();
            alumnoInscripcionesService.Delete(id);
        })
            .WithName("DeleteAlumnoInscripciones")
            .WithOpenApi();

        app.MapGet("/alumnoinscripciones/alumno/{idPersona}", (int idPersona) =>
        {
            AlumnoInscripcionesService alumnoInscripcionesService = new AlumnoInscripcionesService();
            var inscripciones = alumnoInscripcionesService.GetByAlumnoId(idPersona);
            return inscripciones;
        })
        .WithName("GetInscripcionesByAlumnoId")
        .WithOpenApi();

app.MapGet("docentecurso/{id}", (int id) =>
{
    DocenteCursoService docenteCursoService = new DocenteCursoService();
    return docenteCursoService.Get(id);
})
            .WithName("GetDocenteCurso")
            .WithOpenApi();
app.MapGet("/docentecurso", () =>
{
    DocenteCursoService docenteCursoService = new DocenteCursoService();
    return docenteCursoService.GetAll();
})
    .WithName("GetAllDocenteCursos")
    .WithOpenApi();

app.MapPost("/docentecursos", (DocenteCurso docenteCurso) =>
{
    try
    {
        DocenteCursoService docenteCursoService = new DocenteCursoService();
        bool creada = docenteCursoService.Add(docenteCurso);
        if (!creada)
        {
            return Results.Conflict("Docente ya asignado al curso");
        }
        return Results.Ok(docenteCurso);
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.ToString());
        return Results.Problem("Error inesperado en el servidor.");
    }
}).WithName("AgregarDocenteCurso")
    .WithOpenApi();


app.MapPut("/docentecurso", (DocenteCurso docenteCurso) =>
{
    DocenteCursoService docenteCursoService = new DocenteCursoService();
    bool actualizada = docenteCursoService.Update(docenteCurso);
    if (!actualizada)
    {
        return Results.Conflict("Error al actualizar la asignacion");
    }
    return Results.Ok(actualizada);
})
    .WithName("UpdateDocenteCurso")
    .WithOpenApi();

app.MapDelete("/docentecursos/{id}", (int id) =>
{
    DocenteCursoService docenteCursoService = new DocenteCursoService();
    docenteCursoService.Delete(id);
})
    .WithName("DeleteDocenteCurso")
    .WithOpenApi();

app.MapGet("/docentecurso/docente/{idPersona}", (int idPersona) =>
{
    DocenteCursoService docenteCursoService = new DocenteCursoService();
    var asignaciones = docenteCursoService.GetByDocenteId(idPersona);
    return asignaciones;
})
.WithName("GetAsignacionesByDocenteId")
.WithOpenApi();


app.UseAuthorization();
        app.MapControllers();

    
    app.Run();
    