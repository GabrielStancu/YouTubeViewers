using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands;
public class OpenEditYouTubeViewerCommand : CommandBase
{
    private readonly YouTubeViewersListingItemViewModel _youTubeViewersListingItemViewModel;
    private readonly YouTubeViewersStore _youTubeViewersStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public OpenEditYouTubeViewerCommand(YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel,
        YouTubeViewersStore youTubeViewersStore,
        ModalNavigationStore modalNavigationStore)
    {
        _youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
        _youTubeViewersStore = youTubeViewersStore;
        _modalNavigationStore = modalNavigationStore;
    }

    public override void Execute(object? parameter)
    {
        var youTubeViewer = _youTubeViewersListingItemViewModel.YouTubeViewer;
        var editYouTubeViewerViewModel = new EditYouTubeViewerViewModel(youTubeViewer, _youTubeViewersStore, _modalNavigationStore);
        _modalNavigationStore.CurrentViewModel = editYouTubeViewerViewModel;
    }
}
