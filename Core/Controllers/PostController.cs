using Microsoft.AspNetCore.Mvc;
using System.Net;
using DotnetExample.Core.Services;
using DotnetExample.Core.Dto.Post;
using DotnetExample.Core.Models;

namespace DotnetExample.Core.Controllers;

[ApiController()]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<Post>> CreatePost(CreatePostDto data)
    {
        var post = await _postService.CreatePost(data);
        return Created("uri", post);
    }

    [HttpGet]
    public async Task<IEnumerable<Post>> GetPosts()
    {
        var posts = await _postService.GetPosts();
        return posts;
    }

    [HttpGet("{id}")]
    public async Task<Post> GetPost(long id)
    {
        var post = await _postService.GetPost(id);
        return post;
    }

    [HttpPut("{id}")]
    public async Task<Post> UpdatePost(long id, UpdatePostDto data)
    {
        var post = await _postService.UpdatePost(id, data);
        return post;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(long id)
    {
        await _postService.DeletePost(id);
        return Ok();
    }
}