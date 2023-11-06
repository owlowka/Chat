using Chat.DataAccess.Entities;

namespace Chat.DataAccess
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity? Get(Guid id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);

    }
}
