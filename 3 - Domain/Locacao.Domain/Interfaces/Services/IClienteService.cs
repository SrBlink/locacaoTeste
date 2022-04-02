using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task AddAsync(Cliente clienteDto);
        Task<IEnumerable<Cliente>>ObterPorCpfNomeAsync(string busca);
        Task AtualizarEnderecoAsync(Guid id, Cliente cliente);
        Task VerifyExistsAsync(Guid veiculoId);
    }
}