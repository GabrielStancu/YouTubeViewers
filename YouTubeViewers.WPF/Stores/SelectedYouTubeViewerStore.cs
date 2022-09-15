using System;
using YouTubeViewers.WPF.Models;

namespace YouTubeViewers.WPF.Stores;
public class SelectedYouTubeViewerStore
{
    private readonly YouTubeViewersStore _youTubeViewersStore;
    private YouTubeViewer? _selectedYouTubeViewer;

    public SelectedYouTubeViewerStore(YouTubeViewersStore youTubeViewersStore)
    {
        _youTubeViewersStore = youTubeViewersStore;
        _youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
    }

    private void YouTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
    {
        if (youTubeViewer.Id == _selectedYouTubeViewer?.Id)
        {
            SelectedYouTubeViewer = youTubeViewer;
        }
    }

    public YouTubeViewer? SelectedYouTubeViewer
    {
        get => _selectedYouTubeViewer;
        set
        {
            _selectedYouTubeViewer = value;
            SelectedYouTubeViewerChanged?.Invoke();
        }
    }

    public event Action? SelectedYouTubeViewerChanged;
}

