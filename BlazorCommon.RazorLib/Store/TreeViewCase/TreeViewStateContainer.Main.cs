using System.Collections.Immutable;
using BlazorCommon.RazorLib.TreeView.TreeViewClasses;
using Fluxor;

namespace BlazorCommon.RazorLib.Store.TreeViewCase;

[FeatureState]
public partial class TreeViewStateContainer
{
    public TreeViewStateContainer()
    {
        TreeViewStatesList = ImmutableList<TreeViewState>.Empty;
    }

    public ImmutableList<TreeViewState> TreeViewStatesList { get; set; }
}