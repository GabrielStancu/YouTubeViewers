﻿using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels;

public class YouTubeViewersViewModel : ViewModelBase
{
    public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
    public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }

    public ICommand LoadYouTubeViewersCommand { get; }
    public ICommand AddYouTubeViewerCommand { get; }

    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }

    private string _errorMessage = string.Empty;
    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(HasErrorMessage));
        }
    }

    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

    public YouTubeViewersViewModel(YouTubeViewersStore youTubeViewersStore,
        SelectedYouTubeViewerStore selectedYouTubeViewerStore,
        ModalNavigationStore modalNavigationStore)
    {
        YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(youTubeViewersStore, selectedYouTubeViewerStore, modalNavigationStore);
        YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(selectedYouTubeViewerStore);

        LoadYouTubeViewersCommand = new LoadYouTubeViewersCommand(this, youTubeViewersStore);
        AddYouTubeViewerCommand = new OpenAddYouTubeViewerCommand(youTubeViewersStore, modalNavigationStore);
    }

    public static YouTubeViewersViewModel LoadViewModel(YouTubeViewersStore youTubeViewersStore,
        SelectedYouTubeViewerStore selectedYouTubeViewerStore,
        ModalNavigationStore modalNavigationStore)
    {
        var viewModel =
            new YouTubeViewersViewModel(youTubeViewersStore, selectedYouTubeViewerStore, modalNavigationStore);

        viewModel.LoadYouTubeViewersCommand.Execute(null);

        return viewModel;
    }
}