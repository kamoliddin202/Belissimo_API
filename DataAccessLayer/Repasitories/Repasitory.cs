using DataAccessLayer.Data;
using DataAccessLayer.IRepasitory;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repasitories
{
    public class Repasitory<TEntity> : IRepasitory<TEntity> where TEntity : class 
    {
        private readonly AppDbContext _dbContext;

        public Repasitory(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task AddEntityAsync(TEntity entity)
        => await _dbContext.Set<TEntity>().AddAsync(entity);

        public async Task DeleteEntityAsyanc(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllEntitiesAsync()
        => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetEntityByIdAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task UpdateEntityAsyanc(TEntity entity)
        => _dbContext.Set<TEntity>().Update(entity);
    }
}
