using BlazorCommon.RazorLib.WatchWindow.TreeViewClasses;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.TreeViewDisplays;

public partial class TreeViewPropertiesDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewProperties TreeViewProperties { get; set; } = null!;
}