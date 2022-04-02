using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterPorCpfNome(string busca);
        Task<Cliente> GetByIdAsync(Guid id);
        void Update(Cliente cliente);
        Task<Cliente> ObterPorCpfOuCnh(string cpf, string cnh);
        Task<bool> VerifyExists(Guid id);
    }
}
