using BlazorCommon.RazorLib.Store.DialogCase;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.Dialog;

public partial class DialogInitializer : FluxorComponent
{
    [Inject]
    private IState<DialogRecordsCollection> DialogRecordsCollectionWrap { get; set; } = null!;
}