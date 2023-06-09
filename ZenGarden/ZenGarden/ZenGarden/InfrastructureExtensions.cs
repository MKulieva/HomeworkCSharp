using Microsoft.EntityFrameworkCore;
using ZenGarden.Infrastructure;


namespace ZenGarden.Api
{
    public static class InfrastructureExtensions//подключение к БД
    {
        public static IServiceCollection RegisterDataBase(this IServiceCollection services)
        {
            var dbConnectionString = "User ID=postgres; Password=11masha24; Host=localhost; Port=5432; Database=ZenGardenDb;";//формируем строку подключения
            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var currentAssemblyName = typeof(AppDbContext).Assembly.FullName;
                options.UseNpgsql(
                    dbConnectionString,
                    b => b.MigrationsAssembly(currentAssemblyName));
            });

            return services;
        }
    }
}
