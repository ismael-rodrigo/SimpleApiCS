using SimpleApiRest.Domain.Models;
namespace SimpleApiRest.Domain.Entity;

public class UserEntityInput
{
    public string FullName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class UserEntity
{
    private string FullName { get; set; } 
    private string Password { get; set; } 
    
    private UserEntity(string fullName, string password)
    {
        FullName = fullName;
        Password = password;
    }

    public static UserEntity Create(UserEntityInput input)
    {
        return new UserEntity(input.FullName, input.Password);
    }

    public UserModel GetModel()
    {
        return new UserModel
        {
            FullName = FullName,
            Password = Password
        };
    }

}