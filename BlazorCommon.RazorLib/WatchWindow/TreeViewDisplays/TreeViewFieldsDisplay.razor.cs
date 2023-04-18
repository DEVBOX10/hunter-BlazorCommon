using BlazorCommon.RazorLib.WatchWindow.TreeViewClasses;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.TreeViewDisplays;

public partial class TreeViewFieldsDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewFields TreeViewFields { get; set; } = null!;
}