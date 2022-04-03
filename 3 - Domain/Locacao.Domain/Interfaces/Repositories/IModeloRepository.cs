using Locacao.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Repositories
{
    public interface IModeloRepository
    {
        Task<Modelo> GetByIdAsync(Guid modeloId);
        Task<Modelo> GetByNomeAsync(string modeloNome);
    }
}