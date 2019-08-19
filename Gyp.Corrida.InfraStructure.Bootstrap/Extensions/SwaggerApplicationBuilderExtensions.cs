﻿using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.InfraStructure.Bootstrap.Extensions
{
    public static class SwaggerApplicationBuilderExtensions
    {
        public static void UseGypCorridaSwagger(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gyp Corrida API");
            });

        }
    }
}
