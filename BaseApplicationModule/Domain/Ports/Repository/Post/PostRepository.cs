using BaseApplicationModule.Domain.Entities;
using BaseApplicationModule.Domain.Ports.Repository.Shared;

namespace BaseApplicationModule.Domain.Ports.Repository.Post;

public interface IPostRepository : IGenericRepository<PostEntity>
{
    public Task<List<PostEntity>> GetPostsByUserId(int userId);
}