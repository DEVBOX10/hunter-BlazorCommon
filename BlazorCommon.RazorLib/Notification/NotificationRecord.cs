namespace BlazorCommon.RazorLib.Notification;

public record NotificationRecord(
    NotificationKey NotificationKey,
    string Title,
    Type RendererType,
    Dictionary<string, object?>? Parameters,
    TimeSpan NotificationOverlayLifespan);