using Chat.DataAccess.Entities;

namespace Chat.DataAccess
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> Get(Guid id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);

    }
}
