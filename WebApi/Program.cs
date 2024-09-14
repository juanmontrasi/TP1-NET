using Entidades;
using MySqlX.XDevAPI;
using proyecto_academia.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();        
    app.UseHttpLogging();
}
app.UseHttpsRedirection();
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

    especialidadesServicecs.Add(especialidad);
    return especialidad;
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
    MateriasServices materiasServices= new MateriasServices();

    return materiasServices.GetAll();
})
.WithName("GetAllMaterias")
.WithOpenApi();

app.MapPost("/materias", (Materia materia) =>
{
    MateriasServices materiasServices = new MateriasServices();

    materiasServices.Add(materia);
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
    CursosService cursosService= new CursosService();

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

    cursosServices.Add(curso);
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

    comisionesService.Add(comision);
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

app.UseHttpsRedirection();
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

    planesService.Add(plan);
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

app.Run();

