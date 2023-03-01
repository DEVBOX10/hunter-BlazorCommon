using System.Collections.Immutable;
using BlazorCommon.RazorLib.Theme;
using Fluxor;

namespace BlazorCommon.RazorLib.Store.ThemeCase;

/// <summary>
/// Keep the <see cref="ThemeRecordsCollection"/> as a class
/// as to avoid record value comparisons when Fluxor checks
/// if the <see cref="FeatureStateAttribute"/> has been replaced.
/// </summary>
[FeatureState]
public partial class ThemeRecordsCollection
{
    public ThemeRecordsCollection()
    {
        ThemeRecordsList = new []
        {
            ThemeFacts.VisualStudioDarkThemeClone,
            ThemeFacts.VisualStudioLightThemeClone,
        }.ToImmutableList();
    }

    public ImmutableList<ThemeRecord> ThemeRecordsList { get; init; } 
}