using System.Text;
using BlazorCommon.RazorLib.Dimensions;
using BlazorCommon.RazorLib.Store.NotificationCase;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.Notification;

public partial class NotificationDisplay : ComponentBase, IDisposable
{
    [Inject]
    private IDispatcher Dispatcher { get; set; } = null!;
    
    [Parameter, EditorRequired]
    public NotificationRecord NotificationRecord { get; set; } = null!;
    [Parameter, EditorRequired]
    public int Index { get; set; }

    private const int WIDTH_IN_PIXELS = 350;
    private const int HEIGHT_IN_PIXELS = 125;
    private const int RIGHT_OFFSET_IN_PIXELS = 15;
    private const int BOTTOM_OFFSET_IN_PIXELS = 15;
    
    private readonly CancellationTokenSource _notificationOverlayCancellationTokenSource = new();

    private string CssStyleString => GetCssStyleString();

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var notificationRecord = NotificationRecord;
            
            if (notificationRecord.NotificationOverlayLifespan is not null)
            {
                _ = Task.Run(async () =>
                {
                    await Task.Delay(
                        notificationRecord.NotificationOverlayLifespan.Value,
                        _notificationOverlayCancellationTokenSource.Token);
                
                    DisposeNotification();
                });
            }
        }
        
        return base.OnAfterRenderAsync(firstRender);
    }

    private string GetCssStyleString()
    {
        var styleBuilder = new StringBuilder();

        var widthInPixelsInvariantCulture = WIDTH_IN_PIXELS
            .ToCssValue();
        
        var heightInPixelsInvariantCulture = HEIGHT_IN_PIXELS
            .ToCssValue();
        
        styleBuilder.Append($" width: {widthInPixelsInvariantCulture}px;");
        styleBuilder.Append($" height: {heightInPixelsInvariantCulture}px;");
        
        var rightOffsetInPixelsInvariantCulture = RIGHT_OFFSET_IN_PIXELS
            .ToCssValue();
        
        styleBuilder.Append($" right: {rightOffsetInPixelsInvariantCulture}px;");

        var bottomOffsetDueToHeight = HEIGHT_IN_PIXELS * Index;

        var bottomOffsetDueToBottomOffset = BOTTOM_OFFSET_IN_PIXELS * (1 + Index);
        
        var totalBottomOffset = bottomOffsetDueToHeight +
                                bottomOffsetDueToBottomOffset;
        
        var totalBottomOffsetInvariantCulture = totalBottomOffset
            .ToCssValue();
        
        styleBuilder.Append($" bottom: {totalBottomOffsetInvariantCulture}px;");

        return styleBuilder.ToString();
    }
    
    private void DisposeNotification()
    {
        Dispatcher.Dispatch(
            new NotificationRecordsCollection.DisposeAction(
                NotificationRecord.NotificationKey));
    }
    
    public void Dispose()
    {
        _notificationOverlayCancellationTokenSource.Cancel();
    }
}