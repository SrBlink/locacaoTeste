using Locacao.Domain.Entities;
using Locacao.Domain.Exceptions;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Domain.Interfaces.Services;
using Locacao.Infrastructure.CrossCuting.Extensions;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Domain.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        protected readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Cliente cliente)
        {
            cliente.Cpf = cliente.Cpf.RemoveMaskCpfCnpj();

            var cpfValido = cliente.Cpf.CpfValidate();

            if (!cpfValido) throw new DomainException("Insira um cpf válido.");

            if (cliente.DataNascimento > DateTime.Now.AddYears(-18)) throw new DomainException("O Cliente não pode ter menos de 18 anos.");

            var existeCliente = await _repository.ObterPorCpfOuCnhAsync(cliente.Cpf, cliente.Cnh);

            if (existeCliente != null) throw new DomainException("Já existe um cadastro com mesmo cpf ou cnh.");

            await _repository.AddAsync(cliente);
        }

        public async Task<IEnumerable<Cliente>> ObterPorCpfNomeAsync(string busca)
        {
            var cliente = await _repository.ObterPorCpfNomeAsync(busca);
            return cliente;
        }

        public async Task AtualizarEnderecoAsync(Guid id, Cliente clienteModel)
        {
            var cliente = await GetByIdAsync(id);

            cliente.Logradouro = clienteModel.Logradouro;
            cliente.NumeroResidencia = clienteModel.NumeroResidencia;
            cliente.Bairro = clienteModel.Bairro;
            cliente.Cidade = clienteModel.Cidade;

            _repository.Update(cliente);
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            var cliente = await _repository.GetByIdAsync(id);

            if (cliente == null) throw new DomainException("Cliente não encontrado.");

            return cliente;
        }

        public async Task VerifyExistsAsync(Guid id)
        {
            var existCliente = await _repository.VerifyExistsAsync(id);

            if (!existCliente) throw new DomainException("Cliente não encontrado.");
        }
    }
}