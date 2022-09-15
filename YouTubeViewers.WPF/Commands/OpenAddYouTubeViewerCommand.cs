using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands;
public class OpenAddYouTubeViewerCommand : CommandBase
{
    private readonly YouTubeViewersStore _youTubeViewersStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public OpenAddYouTubeViewerCommand(YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
    {
        _youTubeViewersStore = youTubeViewersStore;
        _modalNavigationStore = modalNavigationStore;
    }
    public override void Execute(object? parameter)
    {
        var addYouTubeViewerViewModel = new AddYouTubeViewerViewModel(_youTubeViewersStore, _modalNavigationStore);
        _modalNavigationStore.CurrentViewModel = addYouTubeViewerViewModel;
    }
}
