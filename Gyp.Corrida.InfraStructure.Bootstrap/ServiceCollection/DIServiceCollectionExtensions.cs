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
using Gyp.Corrida.Domain.Corrida;
using Gyp.Corrida.Application.UseCases.File;

namespace Gyp.Corrida.InfraStructure.Bootstrap.ServiceCollection
{
    public static class DIServiceCollectionExtensions
    {
        public static void AddGypCorridaDI(this IServiceCollection services)
        {
            services.AddTransient<IRaceFileService, RaceFileService>();
            services.AddTransient<IRaceFileUseCase, RaceFileUseCase>();
        }
    }
}
