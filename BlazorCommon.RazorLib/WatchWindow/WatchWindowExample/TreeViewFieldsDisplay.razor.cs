using BlazorCommon.RazorLib.WatchWindow.TreeViewImplementations;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.WatchWindowExample;

public partial class TreeViewFieldsDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewFields TreeViewFields { get; set; } = null!;
}