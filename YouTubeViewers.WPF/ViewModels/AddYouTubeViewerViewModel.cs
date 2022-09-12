namespace YouTubeViewers.WPF.ViewModels;
public class AddYouTubeViewerViewModel : ViewModelBase
{
    public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

    public AddYouTubeViewerViewModel()
    {
        YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel();
    }
}
