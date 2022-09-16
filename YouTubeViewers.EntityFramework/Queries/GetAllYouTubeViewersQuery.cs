﻿using Microsoft.EntityFrameworkCore;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.Domain.Queries;

namespace YouTubeViewers.EntityFramework.Queries;
public class GetAllYouTubeViewersQuery : IGetAllYouTubeViewersQuery
{
    private readonly YouTubeViewersDbContextFactory _contextFactory;

    public GetAllYouTubeViewersQuery(YouTubeViewersDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<YouTubeViewer>> Execute()
    {
        await using var context = _contextFactory.Create();
        var youTubeViewerDtos = await context.YouTubeViewers.ToListAsync();

        return youTubeViewerDtos.Select(y => new YouTubeViewer(y.Id, y.Username, y.IsSubscribed, y.IsMember));
    }
}
