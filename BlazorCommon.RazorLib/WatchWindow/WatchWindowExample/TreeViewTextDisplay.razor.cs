using BlazorCommon.RazorLib.WatchWindow.TreeViewImplementations;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.WatchWindowExample;

public partial class TreeViewTextDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewText TreeViewText { get; set; } = null!;
}