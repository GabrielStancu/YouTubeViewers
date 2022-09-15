using System.Windows;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ModalNavigationStore _modalNavigationStore;
    private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
    private readonly YouTubeViewersStore _youTubeViewersStore;
    public App()
    {
        _modalNavigationStore = new ModalNavigationStore();
        _youTubeViewersStore = new YouTubeViewersStore();
        _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore(_youTubeViewersStore);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var youTubeViewersViewModel = new YouTubeViewersViewModel(
             _youTubeViewersStore, 
             _selectedYouTubeViewerStore, 
             _modalNavigationStore);
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(_modalNavigationStore, youTubeViewersViewModel)
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}