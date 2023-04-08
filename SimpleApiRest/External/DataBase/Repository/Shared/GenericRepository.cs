using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleApiRest.Domain.Entities.Shared;
using SimpleApiRest.Domain.Ports.Repository;
using SimpleApiRest.Infra;

namespace SimpleApiRest.External.DataBase.Repository.Shared;

    public class GenericRepository<TInput , TOutput> : IGenericRepository<TInput  ,TOutput> where TOutput : EntityBase
{
    private readonly AppDataContext _dbContext;

    protected GenericRepository(AppDataContext dbContext) => _dbContext = dbContext;
    
    
    public async Task<EntityEntry<TOutput>> AddAsync(TOutput model)
    {
        var modelAdded =  await _dbContext.Set<TOutput>().AddAsync(model);
        await CommitAsync();
        return modelAdded;
    }

    public async Task<TOutput?> FindByIdAsync(int id)
    {
        return await _dbContext.Set<TOutput>().FindAsync(id);
    }

    public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }


}