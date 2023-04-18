using BlazorCommon.RazorLib.WatchWindow.TreeViewClasses;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.TreeViewDisplays;

public partial class TreeViewEnumerableDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewEnumerable TreeViewEnumerable { get; set; } = null!;
}