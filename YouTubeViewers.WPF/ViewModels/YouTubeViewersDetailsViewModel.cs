namespace YouTubeViewers.WPF.ViewModels;
public class YouTubeViewersDetailsViewModel : ViewModelBase
{
    public string Username { get; }
    public string IsSubscribedDisplay { get; }
    public string IsMemberDisplay { get; }

    public YouTubeViewersDetailsViewModel()
    {
        Username = "Glixus";
        IsSubscribedDisplay = "Yes";
        IsMemberDisplay = "No";
    }
}

