using YouTubeViewers.Domain.Commands;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Commands;
public class DeleteYouTubeViewerCommand : IDeleteYouTubeViewerCommand
{
    private readonly YouTubeViewersDbContextFactory _contextFactory;

    public DeleteYouTubeViewerCommand(YouTubeViewersDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Guid id)
    {
        var youTubeViewerDto = new YouTubeViewerDto
        {
            Id = id
        };

        await using var context = _contextFactory.Create();
        context.YouTubeViewers.Remove(youTubeViewerDto);
        await context.SaveChangesAsync();
    }
}
