﻿using System.Windows.Input;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels;

public class YouTubeViewersViewModel : ViewModelBase
{
    public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
    public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
    public ICommand AddYouTubeViewerCommand { get; }

    public YouTubeViewersViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
    {
        YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(selectedYouTubeViewerStore);
        YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(selectedYouTubeViewerStore);
    }
}