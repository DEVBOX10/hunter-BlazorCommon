using BlazorCommon.RazorLib.ComponentRenderers;
using BlazorCommon.RazorLib.ComponentRenderers.Types;
using BlazorCommon.RazorLib.Notification;
using BlazorCommon.RazorLib.Store.NotificationCase;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlazorCommon.RazorLib.BackgroundTaskCase;

public class QueuedHostedService : BackgroundService
{
    private readonly IBlazorCommonComponentRenderers _blazorCommonComponentRenderers;
    private readonly ILogger _logger;  
  
    public QueuedHostedService(
        IBackgroundTaskQueue taskQueue,  
        IBackgroundTaskMonitor taskMonitor,
        IBlazorCommonComponentRenderers blazorCommonComponentRenderers,
        ILoggerFactory loggerFactory)  
    {
        _blazorCommonComponentRenderers = blazorCommonComponentRenderers;
        TaskQueue = taskQueue;
        TaskMonitor = taskMonitor;
        _logger = loggerFactory.CreateLogger<QueuedHostedService>();  
    }  
  
    public IBackgroundTaskQueue TaskQueue { get; }  
    public IBackgroundTaskMonitor TaskMonitor { get; }  
  
    protected async override Task ExecuteAsync(  
        CancellationToken cancellationToken)  
    {  
        _logger.LogInformation("Queued Hosted Service is starting.");  
  
        while (!cancellationToken.IsCancellationRequested)  
        {  
            var backgroundTask = await TaskQueue
                .DequeueAsync(cancellationToken);

            if (backgroundTask is not null)
            {
                try
                {
                    TaskMonitor.SetExecutingBackgroundTask(backgroundTask);
                    await backgroundTask.InvokeWorkItem(cancellationToken);
                }
                catch (Exception ex)
                {
                    var message = ex is OperationCanceledException 
                        ? "Task was cancelled {0}." // {0} => WorkItemName
                        : "Error occurred executing {0}."; // {0} => WorkItemName
                
                    _logger.LogError(
                        ex,
                        message,
                        backgroundTask.Name);

                    if (backgroundTask.Dispatcher is not null &&
                        _blazorCommonComponentRenderers.ErrorNotificationRendererType is not null)
                    {
                        var notificationRecord = new NotificationRecord(
                            NotificationKey.NewNotificationKey(),
                            "ExecutingBackgroundTaskChanged",
                            _blazorCommonComponentRenderers.ErrorNotificationRendererType,
                            new Dictionary<string, object?>
                            {
                                {
                                    nameof(IErrorNotificationRendererType.Message),
                                    string.Format(message, backgroundTask.Name)
                                }
                            },
                            null,
                            IErrorNotificationRendererType.CSS_CLASS_STRING);
        
                        backgroundTask.Dispatcher.Dispatch(
                            new NotificationRecordsCollection.RegisterAction(
                                notificationRecord));
                    }
                }
                finally
                {
                    TaskMonitor.SetExecutingBackgroundTask(null);
                }
            }
        }  
  
        _logger.LogInformation("Queued Hosted Service is stopping.");
    }  
}