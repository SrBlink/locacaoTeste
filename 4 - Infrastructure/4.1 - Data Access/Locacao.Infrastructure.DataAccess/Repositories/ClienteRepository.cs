using Locacao.Domain.Entities.Cliente;
using Locacao.Domain.Interfaces.Repository;
using Locacao.Infrastructure.DataAccess.Context;
using Locacao.Infrastructure.DataAccess.Database;

namespace Locacao.Infrastructure.DataAccess.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly SqlContext _sqlContext;

        public ClienteRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }


     }
}