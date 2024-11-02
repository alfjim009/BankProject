using Microsoft.EntityFrameworkCore;
using OperationService.Repositories;
using OperationService.Repositories.Interfaces;
using OperationService.Services;
using OperationService.Services.Interfaces;

namespace OperationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();


            builder.Services.AddDbContext<OperationServiceDbContext>(
                options => options
                    .UseSqlServer(configuration.GetConnectionString("DbContext") ?? "")
                    .EnableSensitiveDataLogging()
            );

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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