using System.Data;
using SqlLite_TEST.ApplicationController;
using SqlLite_TEST.ApplicationController.Models;
using SqlLite_TEST.DatabaseControler;
using SqlLite_TEST.LogController;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using SqlLite_TEST.ApiContoller;
using Microsoft.AspNetCore.Mvc;

namespace SqlLite_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Utworzenie wymaganych elementow do mojej aplikacji
            Application app = new();
            app.Init();

            //Swagger
            var swagger = WebApplication.CreateBuilder(args);
            swagger.Services.AddControllers();

            // Dodanie usług Swaggera i obsługi API
            swagger.Services.AddEndpointsApiExplorer();
            swagger.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "System Test",
                    Version = "v1",
                    Description = "API do obsługi System Test",
                });
            });

            var api = swagger.Build();

            // Włączenie Swaggera w środowisku deweloperskim
            if (api.Environment.IsDevelopment() || 1==1)
            {
                api.UseSwagger(); // Generowanie dokumentacji
                api.UseSwaggerUI(); // Interaktywny interfejs Swaggera
            }

            api.UseHttpsRedirection();
            api.UseRouting();
            api.MapControllers();

     

            //api.MapGet("/User", (string name, HttpRequest r) =>
            //{
                
            //    if (!ApiHelper.IsAuthorized(r))
            //    {
            //        return Results.Unauthorized();
            //    }

            //    User u = new($"login = '{name}'");

            //    if (u.Id == 0)
            //    {
            //        return Results.NotFound(u);
            //    }
            //    else
            //    {
            //        return Results.Ok(u);
            //    }

                    
            //});


           
            //api.MapPost("/User", (HttpRequest r, User u) =>
            //{
            //    if (!ApiHelper.IsAuthorized(r))
            //    {
            //        return Results.Unauthorized();
            //    }

            //    u.Create();

            //    return Results.Ok(u);
            //})
            //    .WithName("Dodaj użytkownika");


            ////api.MapGet("/api/hello", () => "Hello from API!")
            ////    .WithName("HelloEndpoint");

            //api.MapPost("/api/greet", (string name) => $"Hello, {name}!")
            //    .WithName("GreetUser");

            api.Run();



        }
    }
}
