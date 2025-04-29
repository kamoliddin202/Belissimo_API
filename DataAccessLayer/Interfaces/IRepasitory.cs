namespace DataAccessLayer.IRepasitory
{
    public interface IRepasitory<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllEntitiesAsync();
        public Task<TEntity> GetEntityByIdAsync(int id);
        public Task AddEntityAsync(TEntity entity); 
        public Task UpdateEntityAsyanc(TEntity entity); 
        public Task DeleteEntityAsyanc(int id);
    }
}
