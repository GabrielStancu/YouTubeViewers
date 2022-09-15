using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

    private readonly YouTubeViewersStore _youTubeViewersStore;
    private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;

    public YouTubeViewersListingViewModel(YouTubeViewersStore youTubeViewersStore,
        SelectedYouTubeViewerStore selectedYouTubeViewerStore,
        ModalNavigationStore modalNavigationStore)
    {
        _youTubeViewersStore = youTubeViewersStore;
        _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
        _modalNavigationStore = modalNavigationStore;
        _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

        _youTubeViewersStore.YouTubeViewerCreated += YouTubeViewersStore_YouTubeViewerCreated;
        _youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
    }

    

    protected override void Dispose()
    {
        _youTubeViewersStore.YouTubeViewerCreated -= YouTubeViewersStore_YouTubeViewerCreated;
        _youTubeViewersStore.YouTubeViewerUpdated -= YouTubeViewersStore_YouTubeViewerUpdated; 
        base.Dispose();
    }

    private void YouTubeViewersStore_YouTubeViewerCreated(YouTubeViewer youTubeViewer)
    {
        AddYouTubeViewer(youTubeViewer);
    }

    private void YouTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
    {
        var youTubeViewerViewModel =
            _youTubeViewersListingItemViewModels.FirstOrDefault(y => y.YouTubeViewer.Id == youTubeViewer.Id);

        if (youTubeViewerViewModel is null)
            return;

        youTubeViewerViewModel.Update(youTubeViewer);
    }

    private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
    {
        var itemViewModel =
            new YouTubeViewersListingItemViewModel(youTubeViewer, _youTubeViewersStore, _modalNavigationStore);
        _youTubeViewersListingItemViewModels.Add(itemViewModel);
    }
}