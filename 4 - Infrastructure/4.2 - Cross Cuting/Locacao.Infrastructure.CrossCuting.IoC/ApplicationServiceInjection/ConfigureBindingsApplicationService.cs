using Locacao.Domain.ApplicationService;
using Locacao.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Locacao.Infrastructure.CrossCuting.IoC.ApplicationServiceInjection
{
    public static class ConfigureBindingsApplicationService
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
        }
    }
}