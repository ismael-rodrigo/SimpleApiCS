using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SimpleApiRest.Domain.Ports.Repository;

public interface IGenericRepository<in TModelInput , TModelOutput > where TModelOutput : class
{
    public Task<EntityEntry<TModelOutput>> AddAsync(TModelOutput model);
    public Task<TModelOutput?> FindByIdAsync(int id);
    // public void Remove(Guid guid);
    // public Task<TModelOutput> Update(Guid guid , TModelInput model);

    public Task<int> CommitAsync();
}