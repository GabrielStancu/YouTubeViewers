using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace YouTubeViewers.WPF.ViewModels;

public class YouTubeViewersListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;

    public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels =>
        _youTubeViewersListingItemViewModels;

    public YouTubeViewersListingViewModel()
    {
        _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>
        {
            new YouTubeViewersListingItemViewModel("Mary"),
            new YouTubeViewersListingItemViewModel("Sean"),
            new YouTubeViewersListingItemViewModel("Alan")
        };
    }
}