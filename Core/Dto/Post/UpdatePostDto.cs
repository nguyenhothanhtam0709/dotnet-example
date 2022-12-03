using System.ComponentModel.DataAnnotations;


namespace DotnetExample.Core.Dto.Post;

public class UpdatePostDto
{
    [Required]
    [MinLength(6)]
    public string Title { get; set; }
    public string? Content { get; set; }
}