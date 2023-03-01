using BlazorCommon.RazorLib.WatchWindow.TreeViewImplementations;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.WatchWindowExample;

public partial class TreeViewInterfaceImplementationDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewInterfaceImplementation TreeViewInterfaceImplementation { get; set; } = null!;
}