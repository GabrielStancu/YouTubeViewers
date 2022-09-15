﻿using System;
using System.Threading.Tasks;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands;
public class AddYouTubeViewerCommand : AsyncCommandBase
{
    private readonly AddYouTubeViewerViewModel _addYouTubeViewerViewModel;
    private readonly YouTubeViewersStore _youTubeViewersStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public AddYouTubeViewerCommand(AddYouTubeViewerViewModel addYouTubeViewerViewModel,
        YouTubeViewersStore youTubeViewersStore, 
        ModalNavigationStore modalNavigationStore)
    {
        _addYouTubeViewerViewModel = addYouTubeViewerViewModel;
        _youTubeViewersStore = youTubeViewersStore;
        _modalNavigationStore = modalNavigationStore;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var formViewModel = _addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel;
        var youTubeViewer = new YouTubeViewer(Guid.NewGuid(),
            formViewModel.Username,
            formViewModel.IsSubscribed,
            formViewModel.IsMember);

        try
        {
            await _youTubeViewersStore.Create(youTubeViewer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            _modalNavigationStore.Close();
        }
    }
}
