using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Gyp.Race.InfraStructure.Bootstrap;
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

namespace Gyp.Race.API
{
    /// <summary>
    /// Entry point of the application, help configure the environment AspNet.Core
    /// </summary>
    public class Startup
    {
        private readonly ApplicationStartup _startup;
        /// <summary>
        /// Startup class constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _startup = new ApplicationStartup();
        }

        /// <summary>
        /// Represents a set of key/value application configuration properties
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure startup services
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        public void ConfigureServices(IServiceCollection services)
        {
             _startup.ConfigureServices(services);
        }

        /// <summary>
        /// Implement  initial configurations
        /// </summary>
        /// <param name="app">Define a class that provides the mechanisms to configure an application's request pipeline</param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.NumberFormat.CurrencySymbol = "R$";
            
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            _startup.Configure(app, env);
        }
    }
}
