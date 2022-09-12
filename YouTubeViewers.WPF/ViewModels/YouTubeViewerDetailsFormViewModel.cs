using System.Windows.Input;

namespace YouTubeViewers.WPF.ViewModels;
public class YouTubeViewerDetailsFormViewModel : ViewModelBase
{
    private string _username;
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(CanSubmit));
        }
    }

    private bool _isSubscribed;
    public bool IsSubscribed
    {
        get => _isSubscribed;
        set
        {
            _isSubscribed = value;
            OnPropertyChanged(nameof(IsSubscribed));
        }
    }

    private bool _isMember;
    public bool IsMember
    {
        get => _isMember;
        set
        {
            _isMember = value;
            OnPropertyChanged(nameof(IsMember));
        }
    }

    public bool CanSubmit => !string.IsNullOrEmpty(Username);
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }
}
