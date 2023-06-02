using Notes.Api.Entities;

namespace Notes.Api.Domain;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    public Task<TEntity> GetById(int id);
    public Task<List<TEntity>> GetAllAsync();
    public Task<TEntity> AddAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
}
