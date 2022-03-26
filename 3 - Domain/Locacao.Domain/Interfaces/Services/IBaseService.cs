namespace Locacao.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);
    }
}