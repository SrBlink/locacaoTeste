using Locacao.Domain.Interfaces.Repository;
using Locacao.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Locacao.Infrastructure.CrossCuting.IoC.RepositoryInjection
{
    public static class ConfigureBindingsRepository
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}