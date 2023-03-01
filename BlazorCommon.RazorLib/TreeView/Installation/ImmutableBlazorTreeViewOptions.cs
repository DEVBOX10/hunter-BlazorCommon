namespace BlazorCommon.RazorLib.TreeView.Installation;

public class ImmutableBlazorTreeViewOptions : IBlazorTreeViewOptions
{
    public ImmutableBlazorTreeViewOptions(BlazorTreeViewOptions blazorTreeViewOptions)
    {
        InitializeFluxor = blazorTreeViewOptions.InitializeFluxor;
    }

    public bool InitializeFluxor { get; }
}