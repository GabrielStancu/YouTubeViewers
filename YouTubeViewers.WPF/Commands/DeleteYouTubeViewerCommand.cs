using System;
using System.Threading.Tasks;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands;
public class DeleteYouTubeViewerCommand : AsyncCommandBase
{
    private readonly YouTubeViewersListingItemViewModel _youTubeViewersListingItemViewModel;
    private readonly YouTubeViewersStore _youTubeViewersStore;

    public DeleteYouTubeViewerCommand(YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel,
        YouTubeViewersStore youTubeViewersStore)
    {
        _youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
        _youTubeViewersStore = youTubeViewersStore;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        _youTubeViewersListingItemViewModel.ErrorMessage = string.Empty;
        _youTubeViewersListingItemViewModel.IsDeleting = true;
        
        var youTubeViewer = _youTubeViewersListingItemViewModel.YouTubeViewer;

        try
        {
            await _youTubeViewersStore.Delete(youTubeViewer.Id);
        }
        catch (Exception )
        {
            _youTubeViewersListingItemViewModel.ErrorMessage = "Failed to delete YouTube viewer. Please try again later.";
        }
        finally
        {
            _youTubeViewersListingItemViewModel.IsDeleting = false;
        }
    }
}
