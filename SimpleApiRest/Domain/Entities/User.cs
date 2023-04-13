using SimpleApiRest.Domain.Entities.Shared;
using SimpleApiRest.Domain.Entities.Shared.Username;

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
        
        private UserEntity(UsernameEntity userName , string password)
        {
            UserName = userName.Value;
            Password = password;
        }

        protected UserEntity() { }

        public static UserEntity Create(UserEntityInput input)
        {
            var userName = UsernameEntity.Create(input.UserName);
            return new UserEntity(userName , input.Password);
        }
    }
}
