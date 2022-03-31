using System;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void CommitTransaction();

        bool Commit();

        Task<bool> CommitAsync();
    }
}