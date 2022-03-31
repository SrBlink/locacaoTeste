using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Domain.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        public ClienteService(IClienteRepository repository) : base(repository)
        {
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _repository.AddAsync(cliente);
        }

        public async Task<IEnumerable<Cliente>> ObterPorCpfNome(string busca)
        {
            var cliente = await _repository.ObterPorCpfNome(busca);
            return cliente;
        }

        public async Task UpdateEndereco(Guid id, Cliente clienteModel)
        {
            var cliente = await GetByIdAsync(id);

            cliente.Logradouro = clienteModel.Logradouro;
            cliente.NumeroResidencia = clienteModel.NumeroResidencia;
            cliente.Bairro = clienteModel.Bairro;
            cliente.Cidade = clienteModel.Cidade;

            _repository.Update(cliente);
        }
    }
}