using BlazorCommon.RazorLib.JavaScriptObjects;
using BlazorCommon.RazorLib.TreeView.TreeViewClasses;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorCommon.RazorLib.TreeView.Commands;

public interface ITreeViewCommandParameter
{
    public ITreeViewService TreeViewService { get; }
    public TreeViewState TreeViewState { get; }
    public TreeViewNoType? TargetNode { get; }
    public Func<Task> RestoreFocusToTreeView { get; }
    public ContextMenuFixedPosition? ContextMenuFixedPosition { get; }
    public MouseEventArgs? MouseEventArgs { get; }
    public KeyboardEventArgs? KeyboardEventArgs { get; }
}