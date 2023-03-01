﻿using System.Collections.Immutable;
using BlazorCommon.RazorLib.Menu;
using BlazorCommon.RazorLib.TreeView;
using BlazorCommon.RazorLib.TreeView.Commands;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.WatchWindowExample;

public partial class TextEditorDebugContextMenuDisplay : ComponentBase
{
    [Inject]
    private ITreeViewService TreeViewService { get; set; } = null!;
    
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
                    Task.Run(async () =>
                    {
                        if (treeViewCommandParameter.TargetNode is null)
                            return;
                        
                        await treeViewCommandParameter.TargetNode.LoadChildrenAsync();
                        
                        TreeViewService.ReRenderNode(
                            TextEditorDebugDisplay.TextEditorDebugTreeViewStateKey,
                            treeViewCommandParameter.TargetNode);

                        await InvokeAsync(StateHasChanged);
                    });
                }));
        
        return new MenuRecord(
            menuOptionRecords.ToImmutableArray());
    }
}