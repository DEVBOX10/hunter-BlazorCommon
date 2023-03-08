using BlazorCommon.RazorLib.WatchWindow.TreeViewImplementations;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.WatchWindowExample;

public partial class TreeViewEnumerableDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewEnumerable TreeViewEnumerable { get; set; } = null!;
}