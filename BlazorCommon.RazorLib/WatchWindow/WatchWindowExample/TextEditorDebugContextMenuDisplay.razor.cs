﻿using System.Collections.Immutable;
using BlazorCommon.RazorLib.BackgroundTaskCase;
using BlazorCommon.RazorLib.Menu;
using BlazorCommon.RazorLib.TreeView;
using BlazorCommon.RazorLib.TreeView.Commands;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.WatchWindowExample;

public partial class TextEditorDebugContextMenuDisplay : ComponentBase
{
    [Inject]
    private ITreeViewService TreeViewService { get; set; } = null!;
    [Inject]
    private IBackgroundTaskQueue BackgroundTaskQueue { get; set; } = null!;
    [Inject]
    private IDispatcher Dispatcher { get; set; } = null!;
    
    [Parameter, EditorRequired]
    public ITreeViewCommandParameter TreeViewCommandParameter { get; set; } = null!;
    
    public static string GetContextMenuCssStyleString(ITreeViewCommandParameter? treeViewCommandParameter)
    {
        if (treeViewCommandParameter?.ContextMenuFixedPosition is null)
            return "display: none;";
        
        var left = 
            $"left: {treeViewCommandParameter.ContextMenuFixedPosition.LeftPositionInPixels}px;";
        
        var top = 
            $"top: {treeViewCommandParameter.ContextMenuFixedPosition.TopPositionInPixels}px;";

        return $"{left} {top} position: fixed;";
    }
    
    private MenuRecord GetMenuRecord(
        ITreeViewCommandParameter treeViewCommandParameter)
    {
        var menuOptionRecords = new List<MenuOptionRecord>();
        
        menuOptionRecords.Add(
            new MenuOptionRecord(
                "Refresh",
                MenuOptionKind.Other,
                OnClick: () =>
                {
                    // IBackgroundTaskQueue does not work well here because
                    // this Task does not need to be tracked.
                    _ = Task.Run(async () =>
                    {
                        if (treeViewCommandParameter.TargetNode is null)
                            return;
                        
                        await treeViewCommandParameter.TargetNode.LoadChildrenAsync();
                        
                        TreeViewService.ReRenderNode(
                            TextEditorDebugDisplay.TextEditorDebugTreeViewStateKey,
                            treeViewCommandParameter.TargetNode);

                        await InvokeAsync(StateHasChanged);
                    }, CancellationToken.None);
                }));
        
        return new MenuRecord(
            menuOptionRecords.ToImmutableArray());
    }
}