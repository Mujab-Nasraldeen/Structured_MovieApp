using Movie.API.Extensions;
using Movie.Data.Configurations;
using Movie.Services.Configurations;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Data Layer
builder.Services.AddProjectDataLayer(builder.Configuration);

// Business Layer (Services Layer)
builder.Services.AddApplicationServices();

// API Layer
builder.Services.AddApiLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    builder.WebHost.UseUrls("http://0.0.0.0:7072");
}

app.UseCors("MovieAPI");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();