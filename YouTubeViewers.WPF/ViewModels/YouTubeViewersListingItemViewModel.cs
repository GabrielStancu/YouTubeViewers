using System.Windows.Input;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels;
public class YouTubeViewersListingItemViewModel : ViewModelBase
{
    public YouTubeViewer YouTubeViewer { get; private set; }
    public string Username => YouTubeViewer.Username;
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    private bool _isDeleting;

    public bool IsDeleting
    {
        get => _isDeleting;
        set
        {
            _isDeleting = value;
            OnPropertyChanged(nameof(IsDeleting));
        }
    }

    private string _errorMessage = string.Empty;
    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(HasErrorMessage));
        }
    }

    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

    public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer,
        YouTubeViewersStore youTubeViewersStore,
        ModalNavigationStore modalNavigationStore)
    {
        YouTubeViewer = youTubeViewer;
        EditCommand = new OpenEditYouTubeViewerCommand(this, youTubeViewersStore, modalNavigationStore);
        DeleteCommand = new DeleteYouTubeViewerCommand(this, youTubeViewersStore);
    }

    public void Update(YouTubeViewer youTubeViewer)
    {
        YouTubeViewer = youTubeViewer;
        OnPropertyChanged(nameof(Username)); 
    }
}

