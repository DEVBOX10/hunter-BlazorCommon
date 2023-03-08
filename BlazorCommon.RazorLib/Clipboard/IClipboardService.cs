namespace BlazorCommon.RazorLib.Clipboard;

public interface IClipboardService : IBlazorCommonService
{
    public Task<string> ReadClipboard();
    public Task SetClipboard(string value);
}