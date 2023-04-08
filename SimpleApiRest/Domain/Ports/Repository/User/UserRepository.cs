using SimpleApiRest.Domain.Entities;

namespace SimpleApiRest.Domain.Ports.Repository.User;

public interface IUserRepository : IGenericRepository<UserModelInput , UserModel>
{
    public Task<UserModel?> FindByUserNameAsync(string userName);
}