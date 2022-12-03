using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetExample.Core.Models;


[Table("posts")]
public class Post
{
    [Key]
    public long Id { get; set; }

    [Required]
    [Column(TypeName = "VARCHAR")]
    [StringLength(250)]
    public string Title { get; set; }

    [Column(TypeName = "TEXT")]
    public string? Content { get; set; }
}