using Fluxor;

namespace BlazorCommon.RazorLib.TreeView.Store.TreeViewCase;

public partial class TreeViewStateContainer
{
    private class Effector
    {
        [EffectMethod]
        public async Task HandleMoveRightAction(
            LoadChildrenAction loadChildrenAction,
            IDispatcher dispatcher)
        {
            // Getting a deadlock without ".ConfigureAwait(false)" 
            await loadChildrenAction.TreeViewNoType
                .LoadChildrenAsync()
                .ConfigureAwait(false);
            
            var replaceNodeAction = new ReRenderSpecifiedNodeAction(
                loadChildrenAction.TreeViewStateKey,
                loadChildrenAction.TreeViewNoType);
        
            dispatcher.Dispatch(replaceNodeAction);
        }
    }
}