using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels;

public class YouTubeViewersListingViewModel : ViewModelBase
{
    public YouTubeViewersListingItemViewModel? SelectedYouTubeViewerListingItemViewModel
    {
        get => _youTubeViewersListingItemViewModels
            .FirstOrDefault(y => y.YouTubeViewer.Id == _selectedYouTubeViewerStore.SelectedYouTubeViewer?.Id);
        set => _selectedYouTubeViewerStore.SelectedYouTubeViewer = value?.YouTubeViewer;
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

        _youTubeViewersStore.YouTubeViewersLoaded += YouTubeViewersStore_YouTubeViewersLoaded;
        _youTubeViewersStore.YouTubeViewerCreated += YouTubeViewersStore_YouTubeViewerCreated;
        _youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
        _youTubeViewersStore.YouTubeViewerDeleted += YouTubeViewersStore_YouTubeViewerDeleted;

        _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged += SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;

        _youTubeViewersListingItemViewModels.CollectionChanged += YouTubeViewersListingItemViewModels_CollectionChanged;
    }

    private void SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged()
    {
        OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));
    }

    protected override void Dispose()
    {
        _youTubeViewersStore.YouTubeViewersLoaded -= YouTubeViewersStore_YouTubeViewersLoaded;
        _youTubeViewersStore.YouTubeViewerCreated -= YouTubeViewersStore_YouTubeViewerCreated;
        _youTubeViewersStore.YouTubeViewerUpdated -= YouTubeViewersStore_YouTubeViewerUpdated;
        _youTubeViewersStore.YouTubeViewerDeleted -= YouTubeViewersStore_YouTubeViewerDeleted;

        _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged -= SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;

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

    private void YouTubeViewersStore_YouTubeViewerDeleted(Guid id)
    {
        var itemViewModel = _youTubeViewersListingItemViewModels.FirstOrDefault(y => y.YouTubeViewer.Id == id);

        if (itemViewModel is not null)
        {
            _youTubeViewersListingItemViewModels.Remove(itemViewModel);
        }
    }

    private void YouTubeViewersStore_YouTubeViewersLoaded()
    {
        _youTubeViewersListingItemViewModels.Clear();

        foreach (var youTubeViewer in _youTubeViewersStore.YouTubeViewers)
        {
            AddYouTubeViewer(youTubeViewer);
        }
    }

    private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
    {
        var itemViewModel =
            new YouTubeViewersListingItemViewModel(youTubeViewer, _youTubeViewersStore, _modalNavigationStore);
        _youTubeViewersListingItemViewModels.Add(itemViewModel);
    }

    private void YouTubeViewersListingItemViewModels_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));
    }
}