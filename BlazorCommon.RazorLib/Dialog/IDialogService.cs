using BlazorCommon.RazorLib.Store.DialogCase;
using Fluxor;

namespace BlazorCommon.RazorLib.Dialog;

public interface IDialogService : IBlazorCommonService
{
    public IState<DialogRecordsCollection> DialogRecordsCollectionWrap { get; }

    public void RegisterDialogRecord(DialogRecord dialogRecord);
    public void SetDialogRecordIsMaximized(DialogKey dialogKey, bool isMaximized);
    public void DisposeDialogRecord(DialogKey dialogKey);
}