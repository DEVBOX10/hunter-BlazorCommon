using BlazorCommon.RazorLib.Store.DropdownCase;
using Fluxor;

namespace BlazorCommon.RazorLib.Dropdown;

public interface IDropdownService : IBlazorCommonService
{
    public IState<DropdownsState> DropdownsStateWrap { get; }

    public void AddActiveDropdownKey(DropdownKey dialogRecord);
    public void RemoveActiveDropdownKey(DropdownKey dropdownKey);
    public void ClearActiveDropdownKeysAction();
}