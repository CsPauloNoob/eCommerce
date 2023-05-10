using AutoMapper;
using eCommerce.ProductAPI.Config;
using eCommerce.ProductAPI.Models.Context;
using eCommerce.ProductAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace eCommerce.ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            var connectionString = builder.Configuration["MySQLConnection:MySQLConnectionString"];

            builder.Services.AddDbContext<MySQLContext>(
                options => options.UseMySql(
                    connectionString, new MySqlServerVersion(new Version(8, 0, 32))));


            IMapper mapper = MapConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IProductRepository, ProductRepository>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen( c =>
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.ProductAPI", Version = "v1" }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}