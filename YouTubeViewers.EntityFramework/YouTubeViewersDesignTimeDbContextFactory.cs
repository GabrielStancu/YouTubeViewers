using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YouTubeViewers.EntityFramework;
public class YouTubeViewersDesignTimeDbContextFactory : IDesignTimeDbContextFactory<YouTubeViewersDbContext>
{
    public YouTubeViewersDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder()
            .UseSqlite("Data Source=YouTubeViewers.db")
            .Options;

        return new YouTubeViewersDbContext(options);
    }
}
