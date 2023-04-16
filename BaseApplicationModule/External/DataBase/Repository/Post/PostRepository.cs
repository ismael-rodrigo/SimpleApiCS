using BaseApplicationModule.Domain.Entities;
using BaseApplicationModule.Domain.Ports.Repository.Post;
using BaseApplicationModule.External.DataBase.Repository.Shared;
using BaseApplicationModule.Infra;
using Microsoft.EntityFrameworkCore;

namespace BaseApplicationModule.External.DataBase.Repository.Post;

public class PostEntityImplRepository : GenericRepository<PostEntity> , IPostRepository
{
    private readonly AppDataContext _dbContext;
    public PostEntityImplRepository(AppDataContext dbContext) : base(dbContext) => _dbContext = dbContext;


    public Task<List<PostEntity>> GetPostsByUserId(int userId)
    {
        return _dbContext.Posts.Where(post => post.User.Id == userId).ToListAsync();
    }
}