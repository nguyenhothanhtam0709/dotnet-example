using System.ComponentModel.DataAnnotations;


namespace DotnetExample.Core.Dto.Post;

public class CreatePostDto
{
    [Required]
    [MinLength(6)]
    public string Title { get; set; }
    public string? Content { get; set; }
}