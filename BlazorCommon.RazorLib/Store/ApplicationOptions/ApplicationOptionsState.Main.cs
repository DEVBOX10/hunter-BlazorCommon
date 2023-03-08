using BlazorCommon.RazorLib.Options;
using BlazorCommon.RazorLib.Theme;
using Fluxor;

namespace BlazorCommon.RazorLib.Store.ApplicationOptions;

/// <summary>
/// Keep the <see cref="AppOptionsState"/> as a class
/// as to avoid record value comparisons when Fluxor checks
/// if the <see cref="FeatureStateAttribute"/> has been replaced.
/// </summary>
[FeatureState]
public partial class AppOptionsState
{
    public AppOptionsState()
    {
        Options = new CommonOptions(
            DEFAULT_FONT_SIZE_IN_PIXELS,
            DEFAULT_ICON_SIZE_IN_PIXELS,
            ThemeFacts.VisualStudioDarkThemeClone.ThemeKey);
    }

    public const int DEFAULT_FONT_SIZE_IN_PIXELS = 20;
    public const int DEFAULT_ICON_SIZE_IN_PIXELS = 18;
    public const int MINIMUM_FONT_SIZE_IN_PIXELS = 5;
    public const int MINIMUM_ICON_SIZE_IN_PIXELS = 5;

    public CommonOptions Options { get; set; }
}