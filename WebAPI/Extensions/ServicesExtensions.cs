using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebAPI.Extensions
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Configures the SQL Server database context for the application.
        /// </summary>
        /// <param name="services">The service collection to add the context to.</param>
        /// <param name="configuration">The application's configuration, used to get the connection string.</param>
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"))
            );
        /// <summary>
        /// Registers the Repository Manager as a scoped service in the DI container.
        /// </summary>
        /// <param name="services">The service collection to add the manager to.</param>
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        /// <summary>
        /// Registers the Service Manager as a scoped service in the DI container.
        /// </summary>
        /// <param name="services">The service collection to add the manager to.</param>
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        /// <summary>
        /// Registers the Logger Service as a singleton service in the DI container.
        /// </summary>
        /// <param name="services">The service collection to add the service to.</param>
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();
        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();
        }
    }
}
