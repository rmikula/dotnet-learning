using MinimalAPI_RequestValidation;
using MinimalAPI_RequestValidation.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var services = builder.Services;

services.AddSingleton<Database>();
services.AddOpenApi();

var app = builder.Build();

app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // Add Swagger UI and set where openapi.json is located 
    // app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Demo API"));
    app.UseSwaggerUI();
    app.MapScalarApiReference();
}

// app.UseHttpsRedirection();

app.Run();