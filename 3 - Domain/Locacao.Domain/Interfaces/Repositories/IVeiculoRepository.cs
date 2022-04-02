using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> GetByIdAsync(Guid id);
        Task<Veiculo> ObterPorPlacaAsync(string placa);
        Task AddAsync(Veiculo veiculo);
        Task<IEnumerable<Veiculo>> ConsultarPorPlacaAsync(string placa);
        Task<IEnumerable<Veiculo>> ConsultarPorModeloFabricante(string busca);
        Task<bool> VerifyExists(Guid id);
    }
}
