using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mirante.ToDo.Adapter;
using Mirante.ToDo.Core.Interface.Adapter;
using Mirante.ToDo.Core.Interface.Repository;
using Mirante.ToDo.Core.Interface.Service;
using Mirante.ToDo.Core.Validation;
using Mirante.ToDo.Data.Repository;
using Mirante.ToDo.Service;

namespace Mirante.ToDo.IoC
{
    public static class GeneralConfiguration
    {

        public static void AddGeneralConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            services.AddMemoryCache();
        }

        public static void AddGeneralRepositoryConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
        }

        public static void AddGeneralServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IToDoTaskService, ToDoTaskService>();
        }

        public static void AddGeneralAdapterConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IToDoTaskAdapter, ToDoTaskAdapter>();
        }

        public static void AddGeneralValidationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining<ToDoTaskValidation>();
        }
    }
}
