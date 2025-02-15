using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using UsersMicroservice.API.Middleware;
using UsersMicroservice.Core.Mapper;
using UsersMicroservice.Core;
using UsersMicroservice.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();

//controllers and enum converter
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
//Auto Mapper
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//Fluent validation

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();
app.UseCors();
//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller Routes

app.MapControllers();

app.Run();

