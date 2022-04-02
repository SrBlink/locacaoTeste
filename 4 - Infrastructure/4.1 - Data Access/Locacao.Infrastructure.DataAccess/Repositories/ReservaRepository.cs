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
    public class ReservaRepository : BaseRepository<Reserva, SqlContext>, IReservaRepository
    {
        public ReservaRepository(SqlContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reserva>> ObterReservasAsync(DateTime dataInicial, DateTime dataFinal)
        {
            return await _context.Reserva
                        .Where(x =>
                               x.Data >= dataInicial &&
                               x.Data <= dataFinal &&
                               x.DataRetirada != null &&
                               x.DataDevolucao == null)
                        .Include(x => x.Cliente)
                        .Include(x => x.Veiculo)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Reserva>> ObterReservasClienteAsync(Guid clienteId)
        {
            return await _context.Reserva
                        .Where(x => x.ClienteId == clienteId)
                        .Include(x => x.Cliente)
                        .Include(x => x.Veiculo)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Reserva>> ObterReservasPendentesAsync()
        {
            return await _context.Reserva
                         .Where(x => x.DataDevolucao == null)
                         .Include(x => x.Cliente)
                         .Include(x => x.Veiculo)
                         .ToListAsync();
        }

        public async Task<IEnumerable<Reserva>> ObterReservasVencidasAsync()
        {
            var now = DateTime.Now.Date;

            return await _context.Reserva
                         .Where(x => x.DataPrevistaDevolucao < now && x.DataDevolucao == null)
                         .Include(x => x.Cliente)
                         .Include(x => x.Veiculo)
                         .ToListAsync();
        }
    }
}