using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Locacao.Domain.Services
{
    public class BaseService
    {
        protected readonly IClienteRepository _repository;

        public BaseService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado.");
            }
            return cliente;
        }
    }
}
