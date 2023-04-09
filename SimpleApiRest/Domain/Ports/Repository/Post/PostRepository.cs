using SimpleApiRest.Domain.Entities;
using SimpleApiRest.Domain.Ports.Repository.Shared;

namespace SimpleApiRest.Domain.Ports.Repository.Post;

public interface IPostRepository : IGenericRepository<PostEntity>
{
    public Task<List<PostEntity>> GetPostsByUserId(int userId);
}