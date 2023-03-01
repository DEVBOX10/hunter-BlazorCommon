namespace BlazorCommon.RazorLib;

public record BlazorCommonOptions
{
    /// <summary>
    /// If one already is using Fluxor they can set this property
    /// to false and then in
    ///
    /// AddFluxor(options => options.ScanAssemblies(...))
    ///
    /// Include typeof(BlazorCommonOptions).Assembly
    /// when invoking ScanAssemblies for AddFluxor
    /// service collection extension method
    /// </summary>
    public bool InitializeFluxor { get; init; } = true;

    public BlazorCommonFactories BlazorCommonFactories { get; init; } = new();
}