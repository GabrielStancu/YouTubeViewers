using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Commands;
public class CreateYouTubeViewerCommand : ICreateYouTubeViewerCommand
{
    private readonly YouTubeViewersDbContextFactory _contextFactory;

    public CreateYouTubeViewerCommand(YouTubeViewersDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(YouTubeViewer youTubeViewer)
    {
        var youTubeViewerDto = new YouTubeViewerDto
        {
            Id = youTubeViewer.Id,
            Username = youTubeViewer.Username,
            IsSubscribed = youTubeViewer.IsSubscribed,
            IsMember = youTubeViewer.IsMember
        };

        await using var context = _contextFactory.Create();
        context.YouTubeViewers.Add(youTubeViewerDto);
        await context.SaveChangesAsync();
    }
}
