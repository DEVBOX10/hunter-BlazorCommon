using BlazorCommon.RazorLib.WatchWindow.TreeViewImplementations;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.WatchWindowExample;

public partial class TreeViewPropertiesDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewProperties TreeViewProperties { get; set; } = null!;
}