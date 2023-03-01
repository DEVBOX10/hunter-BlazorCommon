using Microsoft.AspNetCore.Components.Web;

namespace BlazorCommon.RazorLib.Store.DragCase;

public partial class DragState
{
    public record SetDragStateAction(bool ShouldDisplay, MouseEventArgs? MouseEventArgs);
}
