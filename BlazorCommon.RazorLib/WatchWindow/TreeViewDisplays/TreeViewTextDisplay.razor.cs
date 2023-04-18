using BlazorCommon.RazorLib.WatchWindow.TreeViewClasses;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.TreeViewDisplays;

public partial class TreeViewTextDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewText TreeViewText { get; set; } = null!;
}