using Microsoft.EntityFrameworkCore;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework;
public class YouTubeViewersDbContext : DbContext
{
    public YouTubeViewersDbContext(DbContextOptions options) : base(options) { }
    public DbSet<YouTubeViewerDto> YouTubeViewers { get; set; }
}
