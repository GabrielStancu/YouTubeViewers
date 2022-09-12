﻿using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels;

public class YouTubeViewersViewModel : ViewModelBase
{
    public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
    public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
    public ICommand AddYouTubeViewerCommand { get; }

    public YouTubeViewersViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore,
        ModalNavigationStore modalNavigationStore)
    {
        YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(selectedYouTubeViewerStore, modalNavigationStore);
        YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(selectedYouTubeViewerStore);

        AddYouTubeViewerCommand = new OpenAddYouTubeViewerCommand(modalNavigationStore);
    }
}