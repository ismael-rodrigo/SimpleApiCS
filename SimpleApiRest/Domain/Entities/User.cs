using System.ComponentModel.DataAnnotations;
using SimpleApiRest.Domain.Entities.Shared;

namespace SimpleApiRest.Domain.Entities
{
    public class UserModelInput
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    
    public class UserModel : EntityBase
    {
        public string UserName { get; private set; } 
        public string Password { get; private set; } 
        
        private UserModel(string userName , string password)
        {
            UserName = userName;
            Password = password;
        }
        
        public static UserModel Create(UserModelInput input)
        {
            return new UserModel(input.UserName , input.Password);
        }
    }
}
