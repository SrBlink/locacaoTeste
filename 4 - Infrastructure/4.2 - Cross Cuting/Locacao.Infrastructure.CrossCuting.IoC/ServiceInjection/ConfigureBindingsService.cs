using Locacao.Infrastructure.DataAccess.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Locacao.Infrastructure.CrossCuting.IoC.ServiceInjection
{
    public static class ConfigureBindingsService
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            //services.AddScoped<IClienteService, ClienteService>();
            services.AddDbContext<SqlContext>();
        }
    }
}