using Microsoft.EntityFrameworkCore;
using SimpleApiRest.Domain.Entities;
using SimpleApiRest.Domain.Ports.Repository.Post;
using SimpleApiRest.External.DataBase.Repository.Shared;
using SimpleApiRest.Infra;

namespace SimpleApiRest.External.DataBase.Repository.Post;

public class PostEntityImplRepository : GenericRepository<PostEntity> , IPostRepository
{
    private readonly AppDataContext _dbContext;
    public PostEntityImplRepository(AppDataContext dbContext) : base(dbContext) => _dbContext = dbContext;


    public Task<List<PostEntity>> GetPostsByUserId(int userId)
    {
        return _dbContext.Posts.Where(post => post.User.Id == userId).ToListAsync();
    }
}