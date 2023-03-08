using System.Collections;

namespace BlazorCommon.RazorLib;

public class ExtensionInitializersCollection : IEnumerable<ExtensionInitializer>
{
    private readonly List<ExtensionInitializer> _extensionInitializersList = new();
    
    public void Add(ExtensionInitializer extensionInitializer)
    {
        _extensionInitializersList.Add(extensionInitializer);
    }
    
    public IEnumerator<ExtensionInitializer> GetEnumerator()
    {
        return _extensionInitializersList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}