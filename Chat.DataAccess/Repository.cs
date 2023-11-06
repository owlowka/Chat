using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ChatStorageContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ChatStorageContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task Delete(Guid id)
        {
            TEntity? entity = Get(id);

            if (entity is null)
            {
                return;
            }

            _dbSet.Remove(entity);

            await SaveAsync();
        }

        public TEntity? Get(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public async Task Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
