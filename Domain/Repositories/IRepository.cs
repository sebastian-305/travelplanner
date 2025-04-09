namespace travelplanner.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : IEntity
{
    public Task<List<TEntity>> FindAllAsync();
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity?> FindByIdAsync(int id);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task DeleteAsync(TEntity entity);
}

public interface IEntity
{
    public int Id { get; set; }
}
