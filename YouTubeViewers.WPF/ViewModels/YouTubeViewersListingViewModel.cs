using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
    {
        _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>
        {
            new YouTubeViewersListingItemViewModel(new YouTubeViewer("Mary", true, false)),
            new YouTubeViewersListingItemViewModel(new YouTubeViewer("Sean", false, false)),
            new YouTubeViewersListingItemViewModel(new YouTubeViewer("Alan", true, true))
        };

        _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
    }
}