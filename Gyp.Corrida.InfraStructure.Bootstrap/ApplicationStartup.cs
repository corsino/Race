using Gyp.Corrida.InfraStructure.Bootstrap.Extensions;
using Gyp.Corrida.InfraStructure.Bootstrap.ServiceCollection;
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

namespace Gyp.Corrida.InfraStructure.Bootstrap
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           app.UseGypCorridaSwagger();
            app.UseMvc();
        }
    }
}
