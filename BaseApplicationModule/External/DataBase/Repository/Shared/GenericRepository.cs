using BaseApplicationModule.Domain.Entities.Shared;
using BaseApplicationModule.Domain.Ports.Repository.Shared;
using BaseApplicationModule.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BaseApplicationModule.External.DataBase.Repository.Shared;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
{
    private readonly AppDataContext _dbContext;

    protected GenericRepository(AppDataContext dbContext) => _dbContext = dbContext;


    public async Task<List<TEntity>> FindAll()
    {
        var allEntities = await _dbContext.Set<TEntity>().ToListAsync();
        return allEntities;
    }

    public async Task<EntityEntry<TEntity>> AddAsync(TEntity model)
    {
        var modelAdded =  await _dbContext.Set<TEntity>().AddAsync(model);
        await CommitAsync();
        return modelAdded;
    }

    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }


}