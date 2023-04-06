namespace SimpleApiRest
{

    public interface ISettings
    {
        public string AccessSecretKey { get; }
        public string RefreshSecretKey { get; }

    }


    public class Settings : ISettings
    {
        public string AccessSecretKey { get; }
        public string RefreshSecretKey { get; }

        public Settings(
            IConfiguration configuration)
        {
            AccessSecretKey = configuration.GetValue<string>("Jwt:AccessToken:Key");
            RefreshSecretKey = configuration.GetValue<string>("Jwt:RefreshToken:Key");
        }
    };
}
