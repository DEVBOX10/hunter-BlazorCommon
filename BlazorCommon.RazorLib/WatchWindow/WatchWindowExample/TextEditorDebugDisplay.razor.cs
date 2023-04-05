using System.Collections.Immutable;
using BlazorCommon.RazorLib.Dropdown;
using BlazorCommon.RazorLib.TreeView;
using BlazorCommon.RazorLib.TreeView.Commands;
using BlazorCommon.RazorLib.TreeView.TreeViewClasses;
using BlazorCommon.RazorLib.WatchWindow.TreeViewImplementations;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.WatchWindowExample;

public partial class TextEditorDebugDisplay : FluxorComponent
{
    [Inject]
    private ITreeViewService TreeViewService { get; set; } = null!;
    [Inject]
    private IDropdownService DropdownService { get; set; } = null!;
    [Inject]
    private IWatchWindowTreeViewRenderers WatchWindowTreeViewRenderers { get; set; } = null!;

    public static TreeViewStateKey TextEditorDebugTreeViewStateKey { get; } = TreeViewStateKey.NewTreeViewStateKey();
    public static DropdownKey WatchWindowContextMenuDropdownKey { get; } = DropdownKey.NewDropdownKey();
 
    private ITreeViewCommandParameter? _mostRecentTreeViewContextMenuCommandParameter;

    protected override async Task OnInitializedAsync()
    {
        // TODO: Pass in as a Blazor parameter the object to watch
        //
        // if (AuthenticationStateTask is not null)
        // {
        //     var authenticationState = await AuthenticationStateTask;
        //     
        //     if (!TreeViewService.TryGetTreeViewState(
        //             TextEditorDebugTreeViewStateKey, 
        //             out var treeViewState))
        //     {
        //         var rootDebugObject = new TextEditorDebugObjectWrap(
        //             authenticationState,
        //             typeof(AuthenticationState),
        //             nameof(AuthenticationState),
        //             true);
        //     
        //         var rootNode = new TreeViewReflection(
        //             rootDebugObject,
        //             true,
        //             false,
        //             TreeViewRenderers);
        //
        //         TreeViewService.RegisterTreeViewState(new TreeViewState(
        //             TextEditorDebugTreeViewStateKey,
        //             rootNode,
        //             rootNode,
        //             ImmutableList<TreeViewNoType>.Empty));
        //     }
        // }
        
        await base.OnInitializedAsync();
    }
    
    private async Task OnTreeViewContextMenuFunc(ITreeViewCommandParameter treeViewCommandParameter)
    {
        _mostRecentTreeViewContextMenuCommandParameter = treeViewCommandParameter;
        
        DropdownService.AddActiveDropdownKey(
            WatchWindowContextMenuDropdownKey);
        
        await InvokeAsync(StateHasChanged);
    }
}