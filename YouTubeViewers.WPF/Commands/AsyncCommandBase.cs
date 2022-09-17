using System;
using System.Threading.Tasks;

namespace YouTubeViewers.WPF.Commands;
public abstract class AsyncCommandBase : CommandBase
{
    private bool _isExecuting;

    public bool IsExecuting
    {
        get => _isExecuting;
        set
        {
            _isExecuting = value;
            OnCanExecuteChanged();
        }
    }

    public override bool CanExecute(object? parameter)
    {
        return !IsExecuting && base.CanExecute(parameter);
    }

    public override async void Execute(object? parameter)
    {
        try
        {
            await ExecuteAsync(parameter);
        }
        catch (Exception)
        {
            // ignored
        }
    }

    public abstract Task ExecuteAsync(object? parameter);
}
