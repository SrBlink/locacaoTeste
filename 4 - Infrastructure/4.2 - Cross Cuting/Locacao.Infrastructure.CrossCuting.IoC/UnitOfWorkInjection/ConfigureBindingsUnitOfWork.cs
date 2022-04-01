using Locacao.Domain.Interfaces.UoW;
using Locacao.Infrastructure.DataAccess.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Locacao.Infrastructure.CrossCuting.IoC.UnitOfWorkInjection
{
    public static class ConfigureBindingsUnitOfWork
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}