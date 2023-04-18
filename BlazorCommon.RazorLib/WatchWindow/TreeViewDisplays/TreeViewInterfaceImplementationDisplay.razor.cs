using BlazorCommon.RazorLib.WatchWindow.TreeViewClasses;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.TreeViewDisplays;

public partial class TreeViewInterfaceImplementationDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewInterfaceImplementation TreeViewInterfaceImplementation { get; set; } = null!;
}