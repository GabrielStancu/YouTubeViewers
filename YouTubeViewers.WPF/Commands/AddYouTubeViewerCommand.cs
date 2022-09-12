using System.Threading.Tasks;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.Commands;
public class AddYouTubeViewerCommand : AsyncCommandBase
{
    private readonly ModalNavigationStore _modalNavigationStore;

    public AddYouTubeViewerCommand(ModalNavigationStore modalNavigationStore)
    {
        _modalNavigationStore = modalNavigationStore;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        // Add YouTube viewer to database 
        _modalNavigationStore.Close();
    }
}
