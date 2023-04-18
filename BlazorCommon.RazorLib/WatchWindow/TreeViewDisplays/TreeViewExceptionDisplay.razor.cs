using BlazorCommon.RazorLib.WatchWindow.TreeViewClasses;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.TreeViewDisplays;

public partial class TreeViewExceptionDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewException TreeViewException { get; set; } = null!;
}