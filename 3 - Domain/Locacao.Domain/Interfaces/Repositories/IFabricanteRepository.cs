using Locacao.Domain.Entities;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Repositories
{
    public interface IFabricanteRepository
    {
        Task<Fabricante> GetByNomeAsync(string fabricanteNome);
    }
}
