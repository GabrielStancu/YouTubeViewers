using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels;

public class YouTubeViewersListingViewModel : ViewModelBase
{
    public ICommand LoadYouTubeViewersCommand { get; }

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

        LoadYouTubeViewersCommand = new LoadYouTubeViewersCommand(_youTubeViewersStore);

        _youTubeViewersStore.YouTubeViewersLoaded += YouTubeViewersStore_YouTubeViewersLoaded;
        _youTubeViewersStore.YouTubeViewerCreated += YouTubeViewersStore_YouTubeViewerCreated;
        _youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
        _youTubeViewersStore.YouTubeViewerDeleted += YouTubeViewersStore_YouTubeViewerDeleted;
    }

    public static YouTubeViewersListingViewModel LoadViewModel(YouTubeViewersStore youTubeViewersStore,
        SelectedYouTubeViewerStore selectedYouTubeViewerStore,
        ModalNavigationStore modalNavigationStore)
    {
        var viewModel =
            new YouTubeViewersListingViewModel(youTubeViewersStore, selectedYouTubeViewerStore, modalNavigationStore);

        viewModel.LoadYouTubeViewersCommand.Execute(null);

        return viewModel;
    }

    protected override void Dispose()
    {
        _youTubeViewersStore.YouTubeViewersLoaded -= YouTubeViewersStore_YouTubeViewersLoaded;
        _youTubeViewersStore.YouTubeViewerCreated -= YouTubeViewersStore_YouTubeViewerCreated;
        _youTubeViewersStore.YouTubeViewerUpdated -= YouTubeViewersStore_YouTubeViewerUpdated;
        _youTubeViewersStore.YouTubeViewerDeleted -= YouTubeViewersStore_YouTubeViewerDeleted;
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
}