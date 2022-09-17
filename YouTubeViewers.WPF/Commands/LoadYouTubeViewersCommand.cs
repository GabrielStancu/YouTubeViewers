using System;
using System.Threading.Tasks;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands;
public class LoadYouTubeViewersCommand : AsyncCommandBase
{
    private readonly YouTubeViewersViewModel _youTubeViewersViewModel;
    private readonly YouTubeViewersStore _youTubeViewersStore;

    public LoadYouTubeViewersCommand(YouTubeViewersViewModel youTubeViewersViewModel, YouTubeViewersStore youTubeViewersStore)
    {
        _youTubeViewersViewModel = youTubeViewersViewModel;
        _youTubeViewersStore = youTubeViewersStore;
    }

    public override async Task ExecuteAsync(object? parameter)
    { 
        _youTubeViewersViewModel.IsLoading = true;

        try
        {
            await _youTubeViewersStore.Load();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            _youTubeViewersViewModel.IsLoading = false;
        }
    }
}
