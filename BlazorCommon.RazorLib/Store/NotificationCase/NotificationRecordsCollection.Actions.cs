using BlazorCommon.RazorLib.Notification;

namespace BlazorCommon.RazorLib.Store.NotificationCase;

public partial class NotificationRecordsCollection
{
    public record RegisterAction(NotificationRecord NotificationRecord);
    public record DisposeAction(NotificationKey NotificationKey);
}