using BlazorCommon.RazorLib.Store.NotificationCase;
using Fluxor;

namespace BlazorCommon.RazorLib.Notification;

public class NotificationService : INotificationService
{
    private readonly IDispatcher _dispatcher;

    public NotificationService(
        bool isEnabled,
        IDispatcher dispatcher,
        IState<NotificationRecordsCollection> notificationRecordsCollectionWrap)
    {
        _dispatcher = dispatcher;
        IsEnabled = isEnabled;
        NotificationRecordsCollectionWrap = notificationRecordsCollectionWrap;
    }

    public bool IsEnabled { get; }
    public IState<NotificationRecordsCollection> NotificationRecordsCollectionWrap { get; }

    public void RegisterNotificationRecord(NotificationRecord dialogRecord)
    {
        _dispatcher.Dispatch(
            new NotificationRecordsCollection.RegisterAction(
                dialogRecord));
    }
    
    public void DisposeNotificationRecord(NotificationKey dialogKey)
    {
        _dispatcher.Dispatch(
            new NotificationRecordsCollection.DisposeAction(
                dialogKey));
    }
}







