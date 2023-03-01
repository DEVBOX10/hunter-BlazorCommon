using BlazorCommon.RazorLib.WatchWindow.TreeViewImplementations;
using Microsoft.AspNetCore.Components;

namespace BlazorCommon.RazorLib.WatchWindow.WatchWindowExample;

public partial class TreeViewReflectionDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewReflection TreeViewReflection { get; set; } = null!;

    private string GetCssStylingForValue(Type itemType)
    {
        if (itemType == typeof(string))
        {
            return "bte_string-literal";
        }
        else if (itemType == typeof(bool))
        {
            return "bte_keyword";
        }
        else
        {
            return string.Empty;
        }
    }
}