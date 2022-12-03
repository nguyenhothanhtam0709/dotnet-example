using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DotnetExample.Core.Contexts;
using DotnetExample.Core.Models;
using DotnetExample.Core.Dto.Post;
using DotnetExample.Core.Commons.HttpExceptions;

namespace DotnetExample.Core.Services;

public interface IPostService
{
    public Task<Post> CreatePost(CreatePostDto data);
    public Task<IEnumerable<Post>> GetPosts();
    public Task<Post> GetPost(long id);
    public Task<Post> UpdatePost(long id, UpdatePostDto data);
    public Task DeletePost(long id);
}

public class PostService : IPostService
{
    private readonly DatabaseContext _dbContext;
    private readonly IMapper _mapper;

    public PostService(DatabaseContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
        var posts = await _dbContext.Posts.ToListAsync();
        return posts;
    }

    public async Task<Post> GetPost(long id)
    {
        var post = await FindById(id);
        return post;
    }

    public async Task<Post> CreatePost(CreatePostDto data)
    {
        var newPost = _mapper.Map<Post>(data);
        _dbContext.Posts.Add(newPost);
        await _dbContext.SaveChangesAsync();
        return newPost;
    }

    public async Task<Post> UpdatePost(long id, UpdatePostDto data)
    {
        var post = await FindById(id);
        _mapper.Map(data, post);
        _dbContext.Posts.Update(post);
        await _dbContext.SaveChangesAsync();
        return post;
    }

    public async Task DeletePost(long id)
    {
        var post = await FindById(id);
        _dbContext.Posts.Remove(post);
        await _dbContext.SaveChangesAsync();
    }

    private async Task<Post> FindById(long id)
    {
        var post = await _dbContext.Posts.FindAsync(id);
        if (post is null)
        {
            throw new NotFoundHttpException("Post not found");
        }
        return post!;
    }
}