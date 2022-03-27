using Locacao.Domain.Interfaces.Repository;
using Locacao.Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locacao.Infrastructure.DataAccess.Database
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SqlContext _sqlContext;

        public BaseRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Add(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Remove(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _sqlContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _sqlContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            try
            {
                _sqlContext.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}