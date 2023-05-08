using System.Collections.Immutable;
using BlazorCommon.RazorLib.Menu;
using BlazorCommon.RazorLib.TreeView;
using BlazorCommon.RazorLib.TreeView.Commands;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow;

public partial class WatchWindowContextMenuDisplay : ComponentBase
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
                    // IBackgroundTaskQueue does not work well here because
                    // this Task does not need to be tracked.
                    _ = Task.Run(async () =>
                    {
                        try
                        {           
                            if (treeViewCommandParameter.TargetNode is null)
                                return;
                            
                            await treeViewCommandParameter.TargetNode.LoadChildrenAsync();
                            
                            TreeViewService.ReRenderNode(
                                WatchWindowDisplay.WatchWindowDisplayTreeViewStateKey,
                                treeViewCommandParameter.TargetNode);

                            await InvokeAsync(StateHasChanged);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }, CancellationToken.None);
                }));
        
        return new MenuRecord(
            menuOptionRecords.ToImmutableArray());
    }
}