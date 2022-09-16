using System.Windows;
using Microsoft.EntityFrameworkCore;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework;
using YouTubeViewers.EntityFramework.Commands;
using YouTubeViewers.EntityFramework.Queries;
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

    private readonly YouTubeViewersDbContextFactory _contextFactory;
    private readonly IGetAllYouTubeViewersQuery _getAllYouTubeViewersQuery;
    private readonly ICreateYouTubeViewerCommand _createYouTubeViewerCommand;
    private readonly IUpdateYouTubeViewerCommand _updateYouTubeViewerCommand;
    private readonly IDeleteYouTubeViewerCommand _deleteYouTubeViewerCommand;
    public App()
    {
        var connectionString = "Data Source=YouTubeViewers.db";
        var options = new DbContextOptionsBuilder()
            .UseSqlite(connectionString)
            .Options;

        _contextFactory = new YouTubeViewersDbContextFactory(options);
        _getAllYouTubeViewersQuery = new GetAllYouTubeViewersQuery(_contextFactory);
        _createYouTubeViewerCommand = new CreateYouTubeViewerCommand(_contextFactory);
        _updateYouTubeViewerCommand = new UpdateYouTubeViewerCommand(_contextFactory);
        _deleteYouTubeViewerCommand = new DeleteYouTubeViewerCommand(_contextFactory);

        _modalNavigationStore = new ModalNavigationStore();
        _youTubeViewersStore = new YouTubeViewersStore(_getAllYouTubeViewersQuery, 
            _createYouTubeViewerCommand, 
            _updateYouTubeViewerCommand,
            _deleteYouTubeViewerCommand);
        _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore(_youTubeViewersStore);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        // In case you need to apply migrations at startup
        using var context = _contextFactory.Create();
        context.Database.EnsureCreated();

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