
using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Domain.Entities;
using SimpleApiRest.Domain.Ports.Repository.User;
using SimpleApiRest.External.DataBase.Repository.Shared;
using SimpleApiRest.Infra;

namespace SimpleApiRest.External.DataBase.Repository.User;

public class UserEntityImplRepository :  GenericRepository<UserEntity> , IUserRepository 
{
    private readonly AppDataContext _dbContext;
    public UserEntityImplRepository(AppDataContext dbContext) : base(dbContext) => _dbContext = dbContext;
    
    public async Task<UserEntity?> FindByUserNameAsync(string userName)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == userName);
    }
}