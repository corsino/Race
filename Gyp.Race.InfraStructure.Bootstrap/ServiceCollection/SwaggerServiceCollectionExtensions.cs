using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace Gyp.Race.InfraStructure.Bootstrap.ServiceCollection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static void AddGypCorridaSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Gyp Corrida API",
                        Version = "v1"
                    }
                 );

                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, xmlFile);
                config.IncludeXmlComments(filePath);
            });

        }
    }
}
