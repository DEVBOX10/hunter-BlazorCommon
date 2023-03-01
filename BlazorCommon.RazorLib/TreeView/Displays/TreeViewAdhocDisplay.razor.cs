using BlazorCommon.RazorLib.TreeView.TreeViewClasses;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.TreeView.Displays;

public partial class TreeViewAdhocDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewNoType TreeViewNoTypeAdhoc { get; set; } = null!;
}