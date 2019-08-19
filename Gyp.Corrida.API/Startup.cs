using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gyp.Corrida.InfraStructure.Bootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gyp.Corrida.API
{
    public class Startup
    {
        private ApplicationStartup _startup;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _startup = new ApplicationStartup();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
             _startup.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           _startup.Configure(app, env);
        }
    }
}
