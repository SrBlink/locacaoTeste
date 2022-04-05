using Locacao.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Services
{
    public interface IModeloService
    {
        Task<Modelo> GetByIdAsync(Guid modeloId);
        Task<Modelo> GetByNomeAsync(string nome);
    }
}
