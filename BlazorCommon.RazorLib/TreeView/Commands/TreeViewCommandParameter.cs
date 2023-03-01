using BlazorCommon.RazorLib.JavaScriptObjects;
using BlazorCommon.RazorLib.TreeView.TreeViewClasses;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorCommon.RazorLib.TreeView.Commands;

public class TreeViewCommandParameter : ITreeViewCommandParameter
{
    public TreeViewCommandParameter(
        ITreeViewService treeViewService,
        TreeViewState treeViewState,
        TreeViewNoType? focusNode,
        Func<Task> restoreFocusToTreeView,
        ContextMenuFixedPosition? contextMenuFixedPosition,
        MouseEventArgs? mouseEventArgs,
        KeyboardEventArgs? keyboardEventArgs)
    {
        TreeViewService = treeViewService;
        TreeViewState = treeViewState;
        TargetNode = focusNode;
        RestoreFocusToTreeView = restoreFocusToTreeView;
        ContextMenuFixedPosition = contextMenuFixedPosition;
        MouseEventArgs = mouseEventArgs;
        KeyboardEventArgs = keyboardEventArgs;
    }

    public ITreeViewService TreeViewService { get; }
    public TreeViewState TreeViewState { get; }
    public TreeViewNoType? TargetNode { get; }
    public Func<Task> RestoreFocusToTreeView { get; }
    public ContextMenuFixedPosition? ContextMenuFixedPosition { get; }
    public MouseEventArgs? MouseEventArgs { get; }
    public KeyboardEventArgs? KeyboardEventArgs { get; }
}