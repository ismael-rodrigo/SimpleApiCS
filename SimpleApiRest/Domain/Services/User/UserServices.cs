using SimpleApiRest.Domain.Entities;
using SimpleApiRest.Domain.Ports.Repository.User;

namespace SimpleApiRest.Domain.Services.User;

public class UserServices
{
    private readonly IUserRepository _userRepository;
    public UserServices(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> RegisterUser(UserModelInput entityInput)
    {
        var userEntity = UserModel.Create(entityInput);
        var user = await _userRepository.AddAsync(userEntity);
        await _userRepository.CommitAsync();
        return user.Entity;
    }
    
    public async Task<UserModel?> GetUserById(int userId)
    {
        return await _userRepository.FindByIdAsync(userId);
    }
    

}