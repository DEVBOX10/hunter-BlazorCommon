using Microsoft.AspNetCore.Components;
using BlazorCommon.RazorLib.Dialog;

namespace BlazorCommon.RazorLib.RenderTracker;

public partial class RenderTrackerDialogButton : ComponentBase
{
    [Inject]
    private IDialogService DialogService { get; set; } = null!;

    public static readonly DialogKey RenderTrackerDialogKey = DialogKey.NewDialogKey();

    private void ShowRenderTrackerOnClick()
    {
        var renderTrackerDialogRecord = new DialogRecord(
            RenderTrackerDialogKey,
            "Render Tracker",
            typeof(RenderTrackerDisplay),
            null,
            null)
        {
            IsResizable = true,
        };

        DialogService.RegisterDialogRecord(renderTrackerDialogRecord);
    }
}