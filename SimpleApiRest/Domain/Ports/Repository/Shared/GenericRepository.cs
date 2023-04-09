using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SimpleApiRest.Domain.Ports.Repository.Shared;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public Task<List<TEntity>> FindAll();
    public Task<EntityEntry<TEntity>> AddAsync(TEntity model);
    public Task<TEntity?> FindByIdAsync(int id);
    
    // public void Remove(Guid guid);
    // public Task<TModelOutput> Update(Guid guid , TModelInput model);

    public Task<int> CommitAsync();
}