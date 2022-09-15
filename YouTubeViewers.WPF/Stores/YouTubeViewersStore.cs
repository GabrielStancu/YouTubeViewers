using System;
using System.Threading.Tasks;
using YouTubeViewers.WPF.Models;

namespace YouTubeViewers.WPF.Stores;
public class YouTubeViewersStore
{
    public event Action<YouTubeViewer> YouTubeViewerCreated;
    public event Action<YouTubeViewer> YouTubeViewerUpdated;

    public async Task Create(YouTubeViewer youTubeViewer)
    {
        YouTubeViewerCreated?.Invoke(youTubeViewer);
    }

    public async Task Update(YouTubeViewer youTubeViewer)
    {
        YouTubeViewerUpdated?.Invoke(youTubeViewer);
    }
}
