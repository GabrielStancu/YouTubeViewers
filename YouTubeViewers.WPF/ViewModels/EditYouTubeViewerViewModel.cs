namespace YouTubeViewers.WPF.ViewModels;
public class EditYouTubeViewerViewModel : ViewModelBase
{
    public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

    public EditYouTubeViewerViewModel()
    {
        YouTubeViewerDetailsFormViewModel =  new YouTubeViewerDetailsFormViewModel();
    }
}
