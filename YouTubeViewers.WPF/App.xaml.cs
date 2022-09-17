﻿using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework;
using YouTubeViewers.EntityFramework.Commands;
using YouTubeViewers.EntityFramework.Queries;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;
using YouTubeViewers.WPF.HostBuilders;

namespace YouTubeViewers.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .AddDbContext()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IGetAllYouTubeViewersQuery, GetAllYouTubeViewersQuery>();
                services.AddSingleton<ICreateYouTubeViewerCommand, CreateYouTubeViewerCommand>();
                services.AddSingleton<IUpdateYouTubeViewerCommand, UpdateYouTubeViewerCommand>();
                services.AddSingleton<IDeleteYouTubeViewerCommand, DeleteYouTubeViewerCommand>();

                services.AddSingleton<ModalNavigationStore>();
                services.AddSingleton<YouTubeViewersStore>();
                services.AddSingleton<SelectedYouTubeViewerStore>();

                services.AddSingleton<MainViewModel>();
                services.AddTransient<YouTubeViewersViewModel>(CreateYouTubeViewersViewModel);

                services.AddSingleton<MainWindow>(provider => new MainWindow()
                {
                    DataContext = provider.GetRequiredService<MainViewModel>()
                });
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        // In case you need to apply migrations at startup
        var contextFactory = _host.Services.GetRequiredService<YouTubeViewersDbContextFactory>();
        using var context = contextFactory.Create();
        context.Database.Migrate();

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }

    private YouTubeViewersViewModel CreateYouTubeViewersViewModel(IServiceProvider services)
    {
        return YouTubeViewersViewModel.LoadViewModel(
            services.GetRequiredService<YouTubeViewersStore>(),
            services.GetRequiredService<SelectedYouTubeViewerStore>(),
            services.GetRequiredService<ModalNavigationStore>()
        );
    }
}