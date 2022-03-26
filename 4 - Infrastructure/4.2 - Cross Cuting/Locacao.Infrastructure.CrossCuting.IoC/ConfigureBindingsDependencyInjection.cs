using Locacao.Infrastructure.CrossCuting.IoC.ApplicationServiceInjection;
using Locacao.Infrastructure.CrossCuting.IoC.RepositoryInjection;
using Locacao.Infrastructure.CrossCuting.IoC.ServiceInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locacao.Infrastructure.CrossCuting.IoC
{
    public static class ConfigureBindingsDependencyInjection
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            ConfigureBindingsService.RegisterBindings(services);
            ConfigureBindingsRepository.RegisterBindings(services);
            ConfigureBindingsApplicationService.RegisterBindings(services);
        }
    }
}