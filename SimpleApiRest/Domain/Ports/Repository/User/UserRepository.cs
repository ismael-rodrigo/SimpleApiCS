using SimpleApiRest.Domain.Entities;
using SimpleApiRest.Domain.Ports.Repository.Shared;

namespace SimpleApiRest.Domain.Ports.Repository.User;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    public Task<UserEntity?> FindByUserNameAsync(string userName);
}