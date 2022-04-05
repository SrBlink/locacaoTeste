using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repositories;
using Locacao.Infrastructure.DataAccess.Context;
using Locacao.Infrastructure.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locacao.Infrastructure.DataAccess.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente, SqlContext>, IClienteRepository
    {
        public ClienteRepository(SqlContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> ObterPorCpfNomeAsync(string busca)
        {
            var cliente = await _context.Cliente.Where(x => EF.Functions.Like(x.Nome, $"%{busca}%") || EF.Functions.Like(x.Cpf, $"%{busca}%")).ToListAsync();
            return cliente;
        }

        public async Task<Cliente> ObterPorCpfOuCnhAsync(string cpf, string cnh)
        {
            var cliente = await _context.Cliente.Where(x => x.Cpf == cpf || x.Cnh == cnh).FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<bool> VerifyExistsAsync(Guid id)
        {
            return await _context.Cliente.Where(x => x.Id == id).AnyAsync();
        }
    }
}