using BlazorCommon.RazorLib.Store.NotificationCase;
using Fluxor;

namespace BlazorCommon.RazorLib.Notification;

public interface INotificationService : IBlazorCommonService
{
    public IState<NotificationRecordsCollection> NotificationRecordsCollectionWrap { get; }

    public void RegisterNotificationRecord(NotificationRecord notificationRecord);
    public void DisposeNotificationRecord(NotificationKey dialogKey);
}