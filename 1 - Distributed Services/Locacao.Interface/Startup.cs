using Locacao.Infrastructure.CrossCuting.IoC;
using Locacao.Infrastructure.DataAccess.Context;
using Locacao.Interface.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locacao.Interface
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfiguration(Configuration);

            ConfigureBindingsDependencyInjection.RegisterBindings(services, Configuration);

            services.AddSwaggerConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SqlContext sqlContext)
        {
            sqlContext.Database.EnsureCreated();
            app.UseApiConfiguration(env);
            app.UseSwaggerConfiguration();
        }
    }
}