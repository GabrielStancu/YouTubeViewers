using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands;
public class EditYouTubeViewerCommand : AsyncCommandBase
{
    private readonly YouTubeViewersStore _youTubeViewersStore;
    private readonly ModalNavigationStore _modalNavigationStore;
    private readonly EditYouTubeViewerViewModel _editYouTubeViewerViewModel;

    public EditYouTubeViewerCommand(EditYouTubeViewerViewModel editYouTubeViewerViewModel,
        YouTubeViewersStore youTubeViewersStore, 
        ModalNavigationStore modalNavigationStore)
    {
        _youTubeViewersStore = youTubeViewersStore;
        _modalNavigationStore = modalNavigationStore;
        _editYouTubeViewerViewModel = editYouTubeViewerViewModel;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        var formViewModel = _editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel;

        formViewModel.ErrorMessage = string.Empty;
        formViewModel.IsSubmitting = true;

        var youTubeViewer = new YouTubeViewer(_editYouTubeViewerViewModel.YouTubeViewerId,
            formViewModel.Username,
            formViewModel.IsSubscribed,
            formViewModel.IsMember);

        try
        {
            await _youTubeViewersStore.Update(youTubeViewer);
        }
        catch (Exception)
        {
            formViewModel.ErrorMessage = "Failed to edit YouTube viewer. Please try again later.";
        }
        finally
        {
            formViewModel.IsSubmitting = false;
            _modalNavigationStore.Close();
        }
    }
}
