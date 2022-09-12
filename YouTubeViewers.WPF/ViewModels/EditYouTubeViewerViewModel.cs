using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels;
public class EditYouTubeViewerViewModel : ViewModelBase
{
    public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

    public EditYouTubeViewerViewModel(YouTubeViewer youTubeViewer, ModalNavigationStore modalNavigationStore)
    {
        var submitCommand = new EditYouTubeViewerCommand(modalNavigationStore);
        var cancelCommand = new CloseModalCommand(modalNavigationStore);
        YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand)
        {
            Username = youTubeViewer.Username,
            IsSubscribed = youTubeViewer.IsSubscribed,
            IsMember = youTubeViewer.IsMember
        };
    }
}
