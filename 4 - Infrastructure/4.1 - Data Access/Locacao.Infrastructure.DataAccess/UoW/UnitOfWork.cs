using Locacao.Domain.Interfaces.UoW;
using Locacao.Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Locacao.Infrastructure.DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SqlContext context)
        {
            _context = context;
        }

        public void BeginTransaction() => _transaction = _context.Database.BeginTransaction();

        public void CommitTransaction() => _transaction?.Commit();

        public bool Commit()
        {
            _context.SaveChanges();
            ClearEFTracker();
            return true;
        }

        public async Task<bool> CommitAsync()
        {
            await _context.SaveChangesAsync();

            ClearEFTracker();

            return true;
        }

        public void Dispose()
        {
            _transaction?.Dispose();

            _context?.Dispose();

            GC.SuppressFinalize(this);
        }

        private void ClearEFTracker()
        {
            var entries = _context.ChangeTracker.Entries().ToList();

            foreach (var entry in entries)
                entry.State = EntityState.Detached;
        }
    }
}