using SimpleApiRest.Domain.Entities.Shared;

namespace SimpleApiRest.Domain.Entities
{
    public class UserEntityInput
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    
    public class UserEntity : EntityBase
    {
        public string UserName { get; private set; } 
        public string Password { get; private set; } 
        public ICollection<PostEntity> Posts { get; } = new List<PostEntity>();
        
        private UserEntity(string userName , string password)
        {
            UserName = userName;
            Password = password;
        }
        
        public static UserEntity Create(UserEntityInput input)
        {
            return new UserEntity(input.UserName , input.Password);
        }
    }
}
