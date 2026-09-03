using Microsoft.EntityFrameworkCore;

namespace BuildAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database connection
            builder.Services.AddDbContext<Models.Student25Context>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("dbcs")
                )
            );

            var app = builder.Build();

            // Swagger - enabled on Azure Production also
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}