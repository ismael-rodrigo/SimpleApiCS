
using BaseApplicationModule.Domain.Entities;
using BaseApplicationModule.Domain.Ports.Repository.User;
using BaseApplicationModule.External.DataBase.Repository.Shared;
using BaseApplicationModule.Infra;
using Microsoft.EntityFrameworkCore;

namespace BaseApplicationModule.External.DataBase.Repository.User;

public class UserEntityImplRepository :  GenericRepository<UserEntity> , IUserRepository 
{
    private readonly AppDataContext _dbContext;
    public UserEntityImplRepository(AppDataContext dbContext) : base(dbContext) => _dbContext = dbContext;
    
    public async Task<UserEntity?> FindByUserNameAsync(string userName)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == userName);
    }
}