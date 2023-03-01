namespace BlazorCommon.RazorLib.Storage;

public interface IStorageService : IBlazorCommonService
{
    public ValueTask SetValue(string key, object? value);
    public ValueTask<object?> GetValue(string key);
}