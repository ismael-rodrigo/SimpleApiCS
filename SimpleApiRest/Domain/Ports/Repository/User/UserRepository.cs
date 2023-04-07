using SimpleApiRest.Domain.Entity;
using SimpleApiRest.Domain.Models;

namespace SimpleApiRest.Domain.Ports.Repository.User;

public interface IUserRepository : IGenericCrudRepository<UserEntity , UserModel>
{
    public Task<UserModel?> FindByUserName(string userName);
}