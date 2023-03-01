using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.Notification;

public partial class CommonInformativeNotificationDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public string Message { get; set; } = null!;
}