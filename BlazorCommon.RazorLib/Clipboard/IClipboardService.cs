namespace BlazorCommon.RazorLib.Clipboard;

public interface IClipboardService
{
    public Task<string> ReadClipboard();
    public Task SetClipboard(string value);
}