using BaseApplicationModule.Domain.Entities;
using BaseApplicationModule.Domain.Ports.Repository.Post;

namespace BaseApplicationModule.Domain.Services.Post;

public class PostService
{
    private readonly IPostRepository _postRepository;
    public PostService(
        IPostRepository postRepository
        )
    {
        _postRepository = postRepository;
    }
    public async Task<List<PostEntity>> GetPostsByUserId(int userId)
    {
        var posts = await _postRepository.GetPostsByUserId(userId);
        return posts;
    }
    public async Task<List<PostEntity>> FindAllPosts()
    {
        var posts = await _postRepository.FindAll();
        return posts;
    }
    public async Task<PostEntity?> FindPostById(int postId)
    {
        var post = await _postRepository.FindByIdAsync(postId);
        return post;
    }
    
    public async Task<PostEntity> NewPostAsync(PostEntity postEntity)
    {
        var post = await _postRepository.AddAsync(postEntity);
        await  _postRepository.CommitAsync();
        return post.Entity;
    }
    
}