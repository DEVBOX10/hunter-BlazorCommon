using Fluxor;

namespace BlazorCommon.RazorLib.Store.AccountCase;

public partial record AccountState
{
    private class Reducer
    {
        [ReducerMethod]
        public static AccountState ReduceAccountStateWithAction(
            AccountState inAccountState,
            AccountStateWithAction accountStateWithAction)
        {
            return accountStateWithAction.WithAction
                .Invoke(inAccountState);
        }
    }
}