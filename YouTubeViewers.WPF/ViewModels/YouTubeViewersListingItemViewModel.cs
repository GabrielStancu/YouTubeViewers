using System.Windows.Input;
using YouTubeViewers.WPF.Models;

namespace YouTubeViewers.WPF.ViewModels;
public class YouTubeViewersListingItemViewModel : ViewModelBase
{
    public readonly YouTubeViewer YouTubeViewer;
    public string Username => YouTubeViewer.Username;
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer, ICommand editCommand)
    {
        YouTubeViewer = youTubeViewer;
        EditCommand = editCommand;
    }
}

