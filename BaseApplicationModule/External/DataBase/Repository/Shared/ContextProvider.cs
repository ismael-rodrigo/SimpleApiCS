using SimpleApiRest.Infra;
namespace SimpleApiRest.External.DataBase.Repository.Shared;

public class DbContextProvider
{
    public readonly AppDataContext DbContext;

    protected DbContextProvider(AppDataContext dbContext)
    {
        DbContext = dbContext;
    }
    
}