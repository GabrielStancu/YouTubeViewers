using System.Windows.Input;

namespace YouTubeViewers.WPF.ViewModels;
public class YouTubeViewerDetailsFormViewModel : ViewModelBase
{
    private string _username = string.Empty;
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

    private bool _isSubmitting;
    public bool IsSubmitting
    {
        get => _isSubmitting;
        set
        {
            _isSubmitting = value;
            OnPropertyChanged(nameof(IsSubmitting));
        }
    }

    public bool CanSubmit => !string.IsNullOrEmpty(Username);
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

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

    public YouTubeViewerDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
    {
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;
    }
}
