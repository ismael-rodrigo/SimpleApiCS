using BaseApplicationModule.Domain.Entities;
using BaseApplicationModule.Domain.Services.Post;
using BaseApplicationModule.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace BaseApplicationModule.Controllers;

[ApiController]
[Route("post")]
public class PostController : ControllerBase
{
    private readonly PostService _postService;
    public PostController(PostService postService) => _postService = postService;
    
    [HttpGet]
    public async Task<List<PostEntity>> GetAllPosts()
    {
        var allPosts = await _postService.FindAllPosts();
        return allPosts;
    }
    
    [HttpPost]
    public async Task<PostEntity> RegisterNewPost([FromBody] NewPostRequest request )
    {
        var newPost = await _postService.NewPostAsync(
            new PostEntity()
            {
                Title = request.Title,
                Content = request.Content,
                UserId = request.UserId
            });
        return newPost;
    }
    
    [HttpGet]
    [Route("{postId:int}")]
    public async Task<PostEntity?> GetPostById(int postId)
    {
        var post = await _postService.FindPostById(postId);
        return post;
    }
    
    [HttpGet]
    [Route("user/{userId:int}")]
    public async Task<List<PostEntity>> GetPostsByUserId(int userId)
    {
        var post = await _postService.GetPostsByUserId(userId);
        return post;
    }
}