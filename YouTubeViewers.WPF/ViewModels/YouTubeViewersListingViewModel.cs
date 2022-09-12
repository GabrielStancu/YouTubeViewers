using System.Collections.Generic;
using System.Collections.ObjectModel;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels;

public class YouTubeViewersListingViewModel : ViewModelBase
{
    private YouTubeViewersListingItemViewModel _selectedYouTubeViewerListingItemViewModel;
    public YouTubeViewersListingItemViewModel SelectedYouTubeViewerListingItemViewModel
    {
        get => _selectedYouTubeViewerListingItemViewModel;
        set
        {
            _selectedYouTubeViewerListingItemViewModel = value;
            OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));
            _selectedYouTubeViewerStore.SelectedYouTubeViewer =
                _selectedYouTubeViewerListingItemViewModel?.YouTubeViewer;
        } 
    }

    public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels =>
        _youTubeViewersListingItemViewModels;

    private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

    private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;

    public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore,
        ModalNavigationStore modalNavigationStore)
    {
        _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
        _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

        AddYouTubeViewer(new YouTubeViewer("Mary", true, false), modalNavigationStore);
        AddYouTubeViewer(new YouTubeViewer("Sean", false, false), modalNavigationStore);
        AddYouTubeViewer(new YouTubeViewer("Alan", true, true), modalNavigationStore);
    }

    private void AddYouTubeViewer(YouTubeViewer youTubeViewer, ModalNavigationStore modalNavigationStore)
    {
        var editCommand = new OpenEditYouTubeViewerCommand(youTubeViewer, modalNavigationStore);
        var viewModel = new YouTubeViewersListingItemViewModel(youTubeViewer, editCommand);
        _youTubeViewersListingItemViewModels.Add(viewModel);
    }
}