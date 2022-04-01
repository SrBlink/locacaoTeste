using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Infrastructure.DataAccess.Context;
using Locacao.Infrastructure.DataAccess.Database;

namespace Locacao.Infrastructure.DataAccess.Repositories
{
    public class ModeloRepository : BaseRepository<Modelo, SqlContext>, IModeloRepository
    {
        public ModeloRepository(SqlContext context) : base(context)
        {
        }
    }
}