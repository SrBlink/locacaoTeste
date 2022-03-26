using Locacao.Domain.Interfaces.Repository;
using Locacao.Domain.Interfaces.Services;

namespace Locacao.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}