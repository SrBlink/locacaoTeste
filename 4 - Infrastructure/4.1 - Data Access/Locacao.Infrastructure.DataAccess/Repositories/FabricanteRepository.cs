using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Infrastructure.DataAccess.Context;
using Locacao.Infrastructure.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Locacao.Infrastructure.DataAccess.Repositories
{
    public class FabricanteRepository : BaseRepository<Fabricante, SqlContext>, IFabricanteRepository
    {
        public FabricanteRepository(SqlContext context) : base(context)
        {
        }

        public async Task<Fabricante> GetByNomeAsync(string fabricanteNome)
        {
            return await _context.Fabricante.Where(x => x.Nome == fabricanteNome).FirstOrDefaultAsync();
        }
    }
}