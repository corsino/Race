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
using Gyp.Race.Domain.Race.Services;
using Gyp.Race.Application.UseCases.Race;

namespace Gyp.Race.InfraStructure.Bootstrap.ServiceCollection
{
    public static class DIServiceCollectionExtensions
    {
        public static void AddGypCorridaDI(this IServiceCollection services)
        {
            services.AddTransient<IRaceService, RaceService>();
            services.AddTransient<IRaceUseCase, RaceUseCase>();
        }
    }
}
