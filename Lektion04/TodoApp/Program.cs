using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // Viser interaktivt Scalar UI på /scalar/v1
}

app.UseHttpsRedirection(); // omderigerer HTTP til HTTPS, altså hvis man går ind på http://localhost:5000, så bliver man sendt videre til https://localhost:5001

app.UseAuthorization(); // tilføjer middleware til at håndtere autorisation, altså om brugeren har adgang til de forskellige endpoints

app.MapControllers(); // tilføjer middleware til at håndtere routing, altså hvilken controller der skal håndtere hvilken request

app.Run();