using System;
using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.WPF.Stores;
public class SelectedYouTubeViewerStore
{
    private YouTubeViewer? _selectedYouTubeViewer;

    public SelectedYouTubeViewerStore(YouTubeViewersStore youTubeViewersStore)
    {
        youTubeViewersStore.YouTubeViewerCreated += YouTubeViewersStore_YouTubeViewerCreated;
        youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
        youTubeViewersStore.YouTubeViewerDeleted += YouTubeViewersStore_YouTubeViewerDeleted; 
    }

    private void YouTubeViewersStore_YouTubeViewerCreated(YouTubeViewer youTubeViewer)
    {
        SelectedYouTubeViewer = youTubeViewer;
    }

    private void YouTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
    {
        if (youTubeViewer.Id == _selectedYouTubeViewer?.Id)
        {
            SelectedYouTubeViewer = youTubeViewer;
        }
    }
    private void YouTubeViewersStore_YouTubeViewerDeleted(Guid id)
    {
        SelectedYouTubeViewer = null;
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

