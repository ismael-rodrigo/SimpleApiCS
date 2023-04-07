using SimpleApiRest.Domain.Models;
namespace SimpleApiRest.Domain.Entity;

public class UserEntityInput
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class UserEntity
{
    private string UserName { get; set; } 
    private string Password { get; set; } 
    
    private UserEntity(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public static UserEntity Create(UserEntityInput input)
    {
        return new UserEntity(input.UserName, input.Password);
    }

    public UserModel GetModel()
    {
        return new UserModel
        {
            UserName = UserName,
            Password = Password
        };
    }

}