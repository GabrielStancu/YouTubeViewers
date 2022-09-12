using System.Threading.Tasks;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.Commands;
public class EditYouTubeViewerCommand : AsyncCommandBase
{
    private readonly ModalNavigationStore _modalNavigationStore;

    public EditYouTubeViewerCommand(ModalNavigationStore modalNavigationStore)
    {
        _modalNavigationStore = modalNavigationStore;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        // Edit YouTube viewer to database 
        _modalNavigationStore.Close();
    }
}
