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
            TEntity? entity = await Get(id);

            if (entity is null)
            {
                return;
            }

            _dbSet.Remove(entity);

            await SaveAsync();
        }

        public async Task<TEntity?> Get(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Insert(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbSet.Add(entity);
            await SaveAsync();
        }

        public async Task Update(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbSet.Update(entity);
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
