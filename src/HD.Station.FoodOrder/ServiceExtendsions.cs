using HD.Station.FoodOrder.Contracts.Services;
using HD.Station.FoodOrder.Entities;
using HD.Station.FoodOrder.Repository;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace HD.Station.FoodOrder
{
    public static class ServiceExtendsions
    {
        public static void ConfigureServices( this IServiceCollection services)
        {
            services.AddRazorPages();
        }
        public static void ConfigureCores(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void ConfigurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:PostgreSQL"];

            services.AddDbContext<RepositoryContext>(o => o.UseNpgsql(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
           services.AddScoped<IRepositoryWarpper, RepositoryWrapper>();
           // services.AddScoped<IDishRepository, DishRepository>();
        }
    }
}
