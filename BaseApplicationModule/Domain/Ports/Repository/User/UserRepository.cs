using BaseApplicationModule.Domain.Entities;
using BaseApplicationModule.Domain.Ports.Repository.Shared;

namespace BaseApplicationModule.Domain.Ports.Repository.User;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    public Task<UserEntity?> FindByUserNameAsync(string userName);
}