using System.Collections.Immutable;
using BlazorCommon.RazorLib.ComponentRenderers;
using BlazorCommon.RazorLib.Dropdown;
using BlazorCommon.RazorLib.TreeView;
using BlazorCommon.RazorLib.TreeView.Commands;
using BlazorCommon.RazorLib.TreeView.TreeViewClasses;
using BlazorCommon.RazorLib.WatchWindow.TreeViewClasses;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow;

public partial class WatchWindowDisplay : FluxorComponent
{
    [Inject]
    private ITreeViewService TreeViewService { get; set; } = null!;
    [Inject]
    private IDropdownService DropdownService { get; set; } = null!;
    [Inject]
    private IBlazorCommonComponentRenderers BlazorCommonComponentRenderers { get; set; } = null!;

    [Parameter, EditorRequired]
    public WatchWindowObjectWrap WatchWindowObjectWrap { get; set; } = null!;

    public static TreeViewStateKey WatchWindowDisplayTreeViewStateKey { get; } = TreeViewStateKey.NewTreeViewStateKey();
    public static DropdownKey WatchWindowContextMenuDropdownKey { get; } = DropdownKey.NewDropdownKey();
 
    private ITreeViewCommandParameter? _mostRecentTreeViewContextMenuCommandParameter;
    private bool _disposed;
    
    protected override async Task OnInitializedAsync()
    {
        if (!TreeViewService.TryGetTreeViewState(
                WatchWindowDisplayTreeViewStateKey, 
                out var treeViewState))
        {
            var rootNode = new TreeViewReflection(
                WatchWindowObjectWrap,
                true,
                false,
                BlazorCommonComponentRenderers.WatchWindowTreeViewRenderers!);
    
            TreeViewService.RegisterTreeViewState(new TreeViewState(
                WatchWindowDisplayTreeViewStateKey,
                rootNode,
                rootNode,
                ImmutableList<TreeViewNoType>.Empty));
        }
        
        await base.OnInitializedAsync();
    }
    
    private async Task OnTreeViewContextMenuFunc(ITreeViewCommandParameter treeViewCommandParameter)
    {
        _mostRecentTreeViewContextMenuCommandParameter = treeViewCommandParameter;
        
        DropdownService.AddActiveDropdownKey(
            WatchWindowContextMenuDropdownKey);
        
        await InvokeAsync(StateHasChanged);
    }
    
    protected override void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }
    
        if (disposing)
        {
            TreeViewService.DisposeTreeViewState(
                WatchWindowDisplayTreeViewStateKey);
        }
    
        _disposed = true;
        
        base.Dispose(disposing);
    }
}