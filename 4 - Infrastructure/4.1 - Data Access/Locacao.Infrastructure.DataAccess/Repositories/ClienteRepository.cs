using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Infrastructure.DataAccess.Context;
using Locacao.Infrastructure.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Locacao.Infrastructure.DataAccess.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente, SqlContext>, IClienteRepository
    {
        public ClienteRepository(SqlContext context) : base(context)
        {
        }
    }
}