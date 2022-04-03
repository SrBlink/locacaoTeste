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
    public class VeiculoRepository : BaseRepository<Veiculo, SqlContext>, IVeiculoRepository
    {
        public VeiculoRepository(SqlContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Veiculo>> ConsultarPorModeloFabricanteAsync(string busca)
        {
            return await (from veiculo in _context.Veiculo
                          join m in _context.Modelo on veiculo.ModeloId equals m.Id
                          join f in _context.Fabricante on m.FabricanteId equals f.Id
                          where EF.Functions.Like(m.Nome, $"%{busca.ToLower()}%") || EF.Functions.Like(f.Nome, $"%{busca.ToLower()}%")
                          select new Veiculo
                          {
                              Id = veiculo.Id,
                              Placa = veiculo.Placa,
                              ModeloId = veiculo.ModeloId,
                              Modelo = new Modelo
                              {
                                  Id = m.Id,
                                  Nome = m.Nome,
                                  FabricanteId = m.FabricanteId,
                                  Fabricante = new Fabricante
                                  {
                                      Id = f.Id,
                                      Nome = f.Nome,
                                  }
                              },
                          }

                          ).ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> ConsultarPorPlacaAsync(string placa)
        {
            return await _context.Veiculo
                                    .Where(x => EF.Functions.Like(x.Placa, $"%{placa.ToLower()}%"))
                                    .Include(x => x.Modelo)
                                    .ThenInclude(x => x.Fabricante)
                                    .ToListAsync();
        }

        public async Task<Veiculo> ObterPorPlacaAsync(string placa)
        {
            return await _context.Veiculo
                         .Where(x => x.Placa.Equals(placa))
                         .Include(x => x.Modelo)
                         .ThenInclude(x => x.Fabricante)
                         .FirstOrDefaultAsync();
        }

        public async Task<bool> VerifyExistsAsync(Guid id)
        {
            return await _context.Veiculo.Where(x => x.Id == id).AnyAsync();
        }
    }
}