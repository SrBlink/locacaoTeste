using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Infrastructure.DataAccess.Context;
using Locacao.Infrastructure.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Locacao.Infrastructure.DataAccess.Repositories
{
    public class ModeloRepository : BaseRepository<Modelo, SqlContext>, IModeloRepository
    {
        public ModeloRepository(SqlContext context) : base(context)
        {
        }

        public async Task<Modelo> GetByNomeAsync(string modeloNome)
        {
            return await _context.Modelo.Where(x => x.Nome == modeloNome).Include(x => x.Fabricante).FirstOrDefaultAsync();
        }
    }
}