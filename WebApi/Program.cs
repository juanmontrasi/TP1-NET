using Entidades;
using MySqlX.XDevAPI;
using proyecto_academia.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Falta configurar de manera correcta        
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

