using System;
using System.Collections.Generic;

namespace Locacao.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);
    }
}