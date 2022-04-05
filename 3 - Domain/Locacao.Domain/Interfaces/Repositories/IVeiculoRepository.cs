using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> GetByIdAsync(Guid id);
        Task<Veiculo> ObterPorPlacaAsync(string placa);
        Task AddAsync(Veiculo veiculo);
        Task<IEnumerable<Veiculo>> ConsultarPorPlacaAsync(string placa);
        Task<IEnumerable<Veiculo>> ConsultarPorModeloFabricanteAsync(string busca);
        Task<bool> VerifyExistsAsync(Guid id);
    }
}
