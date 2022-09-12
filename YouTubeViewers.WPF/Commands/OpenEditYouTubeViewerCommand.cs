using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands;
public class OpenEditYouTubeViewerCommand : CommandBase
{
    private readonly YouTubeViewer _youTubeViewer;
    private readonly ModalNavigationStore _modalNavigationStore;

    public OpenEditYouTubeViewerCommand(YouTubeViewer youTubeViewer, ModalNavigationStore modalNavigationStore)
    {
        _youTubeViewer = youTubeViewer;
        _modalNavigationStore = modalNavigationStore;
    }

    public override void Execute(object? parameter)
    {
        var editYouTubeViewerViewModel = new EditYouTubeViewerViewModel(_youTubeViewer, _modalNavigationStore);
        _modalNavigationStore.CurrentViewModel = editYouTubeViewerViewModel;
    }
}
