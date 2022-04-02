using Locacao.Application.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace Locacao.Infrastructure.CrossCuting.IoC.ValidatorInjection
{
    public static class ConfigureBindingsValidator
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<ClienteRequestPostDtoValidator>();
            services.AddScoped<ClienteEnderecoRequestPatchDtoValidator>();
        }
    }
}