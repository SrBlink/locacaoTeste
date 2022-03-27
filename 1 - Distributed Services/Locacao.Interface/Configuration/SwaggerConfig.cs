using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Locacao.Interface.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Locacao - API",
                    Description = "API para fazer reserva de veiculos."
                });

                //var securitySchema = new OpenApiSecurityScheme
                //{
                //    Description = "Cabeçalho de autorização JWT usando o esquema Bearer. Exemplo: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey
                //};
                //c.AddSecurityDefinition("Bearer", securitySchema);

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            }
                //        },
                //        Array.Empty<string>()
                //    }
                //});

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });
                c.DocInclusionPredicate((name, api) => true);
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            var basePath = "";
            app.UseSwagger(options =>
            {
                options.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    var serverUrl = "";
                    if (httpReq.Headers["Host"].ToString().Contains("localhost"))
                    {
                        serverUrl = $"{httpReq.Scheme}://{httpReq.Host.Value}";
                        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = serverUrl } };
                    }
                    else
                    {
                        basePath = "serverproduction";
                        serverUrl = $"https://{httpReq.Headers["Host"]}/{basePath}";
                        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = serverUrl } };
                    }
                    Console.WriteLine($"SERVER SWAGGER: {serverUrl}");
                });
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
                c.DefaultModelsExpandDepth(-1);
                if (!string.IsNullOrEmpty(basePath))
                    c.RoutePrefix = basePath;
            });
        }
    }
}