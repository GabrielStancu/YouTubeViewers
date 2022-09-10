using System.Windows.Input;

namespace YouTubeViewers.WPF.ViewModels;

public class YouTubeViewersViewModel : ViewModelBase
{
    public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
    public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
    public ICommand AddYouTubeViewerCommand { get; }

    public YouTubeViewersViewModel()
    {
        YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel();
        YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel();
    }
}