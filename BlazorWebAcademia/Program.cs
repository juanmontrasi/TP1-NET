using BlazorWebAcademia;
using BlazorWebAcademia.Servicios;
using BlazorWebAcademia_EspecialidadesApi;
using BlazorWebAcademia_PlanesApi;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7111/") });


builder.Services.AddScoped<PlanesApi>();
builder.Services.AddScoped<EspecialidadesApi>();
builder.Services.AddScoped<UsuariosApi>();
builder.Services.AddSingleton<UsuarioState>();

await builder.Build().RunAsync();
