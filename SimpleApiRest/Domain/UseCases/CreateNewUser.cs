using SimpleApiRest.Domain.Entity;
using SimpleApiRest.Domain.Models;
using SimpleApiRest.Domain.Ports.Repository.User;

namespace SimpleApiRest.Domain.UseCases;

public class CreateNewUser
{
    private readonly IUserRepository _userRepository;
    public CreateNewUser(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> Execute(UserEntityInput entityInput)
    {
        var userEntity = UserEntity.Create(entityInput);
        return await _userRepository.Add(userEntity);
    }


}