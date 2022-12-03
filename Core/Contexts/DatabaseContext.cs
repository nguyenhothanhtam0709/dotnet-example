using Microsoft.EntityFrameworkCore;
using DotnetExample.Core.Models;

namespace DotnetExample.Core.Contexts;

public class DatabaseContext : DbContext
{

    private readonly IConfiguration _configuration;
    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(_configuration.GetConnectionString("Sqlite"));
    }

    public DbSet<Post> Posts { get; set; } = null!;
}