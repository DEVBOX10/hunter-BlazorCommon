using BlazorCommon.RazorLib.Resize;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.Dialog;

public partial class DialogDisplay
{
    [Inject]
    private IDialogService DialogService { get; set; } = null!;

    [Parameter]
    public DialogRecord DialogRecord { get; set; } = null!;

    private ResizableDisplay? _resizableDisplay;

    private string ElementDimensionsStyleCssString => DialogRecord.ElementDimensions.StyleString;
    private string IsMaximizedStyleCssString => DialogRecord.IsMaximized
        ? "width: 100vw; height: 100vh; left: 0; top: 0;"
        : string.Empty;
    
    private async Task ReRenderAsync()
    {
        await InvokeAsync(StateHasChanged);
    }

    private void SubscribeMoveHandle()
    {
        _resizableDisplay?.SubscribeToDragEventWithMoveHandle();
    }
    
    private void ToggleIsMaximized()
    {
        DialogService.SetDialogRecordIsMaximized(
            DialogRecord.DialogKey,
            !DialogRecord.IsMaximized);
    }
    
    private void DispatchDisposeDialogRecordAction()
    {
        DialogService.DisposeDialogRecord(
            DialogRecord.DialogKey);
    }
}