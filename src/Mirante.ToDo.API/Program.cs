
using Microsoft.OpenApi.Models;
using Mirante.ToDo.IoC;
using Newtonsoft.Json;
using System.Globalization;
using System.Reflection;

namespace Mirante.ToDo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cultureInfo = new CultureInfo("pt-BR");


            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ToDo API",
                    Version = "v1"
                });
            });

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(new[]
                {
                    Assembly.GetExecutingAssembly(),
                    Assembly.Load("Mirante.ToDo.Api"),
                    Assembly.Load("Mirante.ToDo.Core")
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.AddEntityFrameworkConfiguration(builder.Configuration);
            builder.Services.AddGeneralRepositoryConfiguration(builder.Configuration);
            builder.Services.AddGeneralAdapterConfiguration(builder.Configuration);
            builder.Services.AddGeneralServiceConfiguration(builder.Configuration);
            builder.Services.AddGeneralValidationConfiguration(builder.Configuration);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            var app = builder.Build();

            app.UseCors("CorsPolicy");

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(options =>
                {
                    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
                });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API v1");
                });
            }
            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
