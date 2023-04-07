namespace SimpleApiRest.Domain.Ports.Repository;

public interface IGenericCrudRepository<in TModelInput , TModelOutput >
{
    public Task<TModelOutput> Add(TModelInput model);
    public Task<TModelOutput> FindById(Guid guid);
    public void Remove(Guid guid);
    public Task<TModelOutput> Update(Guid guid , TModelInput model);
}