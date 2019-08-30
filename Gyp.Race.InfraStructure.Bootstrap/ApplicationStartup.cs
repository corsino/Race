using Gyp.Race.InfraStructure.Bootstrap.Extensions;
using Gyp.Race.InfraStructure.Bootstrap.ServiceCollection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Race.InfraStructure.Bootstrap
{
    public class ApplicationStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddGypCorridaSwagger();
            services.AddGypCorridaDI();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           app.UseGypCorridaSwagger();
            app.UseMvc();
        }
    }
}
