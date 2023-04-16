using BaseApplicationModule.Domain.Entities;
using BaseApplicationModule.Domain.Ports.Repository.User;
using Microsoft.AspNetCore.Mvc;

namespace BaseApplicationModule.Domain.Services.User;

public class UserServices
{
    private readonly IUserRepository _userRepository;
    public UserServices(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserEntity> RegisterUser(UserEntityInput entityInput)
    {
        var userAlreadyExists = await _userRepository.FindByUserNameAsync(entityInput.UserName);
        if (userAlreadyExists != null)
        {
            throw new Exception("User Already Exists");
        }
        
        var userEntity = UserEntity.Create(entityInput);
        var user = await _userRepository.AddAsync(userEntity);
        await _userRepository.CommitAsync();
        return user.Entity;
    }
    
    public async Task<UserEntity?> GetUserById(int userId)
    {
        return await _userRepository.FindByIdAsync(userId);
    }


    public async Task<List<UserEntity>> FindAllAsync()
    {
        return await _userRepository.FindAll();
    }
}