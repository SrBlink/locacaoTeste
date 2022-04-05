using Locacao.Domain.Entities;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Services
{
    public interface IFabricanteService
    {
        Task<Fabricante> GetByNomeAsync(string nome);
    }
}
