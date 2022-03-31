using Locacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task AddAsync(Cliente clienteDto);
        Task<IEnumerable<Cliente>>ObterPorCpfNome(string busca);
    }
}