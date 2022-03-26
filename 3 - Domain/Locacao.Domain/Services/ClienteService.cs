using Locacao.Domain.Entities.Cliente;
using Locacao.Domain.Interfaces.Repository;
using Locacao.Domain.Interfaces.Services;

namespace Locacao.Domain.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}