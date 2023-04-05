using BlazorCommon.RazorLib.ComponentRenderers;
using BlazorCommon.RazorLib.ComponentRenderers.Types;
using BlazorCommon.RazorLib.Notification;
using BlazorCommon.RazorLib.Store.NotificationCase;

namespace BlazorCommon.RazorLib.BackgroundTaskCase;

public class BackgroundTaskMonitor : IBackgroundTaskMonitor
{
    private readonly IBlazorCommonComponentRenderers _blazorCommonComponentRenderers;

    public BackgroundTaskMonitor(
        IBlazorCommonComponentRenderers blazorCommonComponentRenderers)
    {
        _blazorCommonComponentRenderers = blazorCommonComponentRenderers;
    }
    
    public IBackgroundTask? ExecutingBackgroundTask { get; private set; }
    
    public event Action? ExecutingBackgroundTaskChanged;

    public void SetExecutingBackgroundTask(IBackgroundTask? backgroundTask)
    {
        ExecutingBackgroundTask = backgroundTask;
        ExecutingBackgroundTaskChanged?.Invoke();

        if (backgroundTask is not null &&
            backgroundTask.ShouldNotifyWhenStartingWorkItem &&
            backgroundTask.Dispatcher is not null &&
            _blazorCommonComponentRenderers.BackgroundTaskDisplayRendererType is not null)
        {
            var notificationRecord = new NotificationRecord(
                NotificationKey.NewNotificationKey(),
                $"Starting: {backgroundTask.Name}",
                _blazorCommonComponentRenderers.BackgroundTaskDisplayRendererType,
                new Dictionary<string, object?>
                {
                    {
                        nameof(IBackgroundTaskDisplayRendererType.BackgroundTask),
                        backgroundTask
                    }
                },
                null,
                null);
        
            backgroundTask.Dispatcher.Dispatch(
                new NotificationRecordsCollection.RegisterAction(
                    notificationRecord));
        }
    }
}