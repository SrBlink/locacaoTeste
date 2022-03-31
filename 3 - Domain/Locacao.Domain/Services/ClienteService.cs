using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Services
{
    public class ClienteService : BaseService , IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository; 

        }

        public async Task AddAsync(Cliente cliente)
        {
            await _repository.AddAsync(cliente);
        }
    }
}
