
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;


namespace PizzaStore_MinimalAPI_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PizzaStore API",
                    Description = "Making the Pizzas you love",
                    Version = "v1"
                });
            });

            builder.Services.AddDbContext<PizzaDb>(option => option.UseInMemoryDatabase("items"));

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
            });

            app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());

            app.Run();
        }
    }
}
