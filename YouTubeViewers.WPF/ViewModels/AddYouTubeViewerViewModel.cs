using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels;
public class AddYouTubeViewerViewModel : ViewModelBase
{
    public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

    public AddYouTubeViewerViewModel(ModalNavigationStore modalNavigationStore)
    {
        var submitCommand = new AddYouTubeViewerCommand(modalNavigationStore);
        var cancelCommand = new CloseModalCommand(modalNavigationStore);
        YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand);
    }
}
