using BlazorWeb.Components;
using BlazorWeb;
using BlazorWeb.Api;
using Microsoft.EntityFrameworkCore;
using BlazorWeb.Servicios;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContext<AcademiaDbContextBlazor>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<DocenteCursosApi>();
builder.Services.AddScoped<UsuariosApi>();
builder.Services.AddScoped<UsuariosService>();
builder.Services.AddSingleton<UsuarioState>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
