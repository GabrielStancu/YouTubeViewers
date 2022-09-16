using System;
using System.Threading.Tasks;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.Commands;
public class LoadYouTubeViewersCommand : AsyncCommandBase
{
    private readonly YouTubeViewersStore _youTubeViewersStore;

    public LoadYouTubeViewersCommand(YouTubeViewersStore youTubeViewersStore)
    {
        _youTubeViewersStore = youTubeViewersStore;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        try
        {
            await _youTubeViewersStore.Load();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
